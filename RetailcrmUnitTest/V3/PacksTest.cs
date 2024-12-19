using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retailcrm;
using Retailcrm.Versions.V3;

namespace RetailcrmUnitTest.V3
{
    [TestClass]
    public class PacksTest
    {
        private readonly Client _client;

        public PacksTest()
        {
            _client = new Client(
                Environment.GetEnvironmentVariable("RETAILCRM_URL"),
                Environment.GetEnvironmentVariable("RETAILCRM_KEY")
            );
        }

        [TestMethod]
        [Ignore]
        public async Task PacksCreateUpdateReadDelete()
        {
            string uid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 12);

            Dictionary<string, object> order = new Dictionary<string, object>
            {
                { "number", $"packs-test-{uid}" },
                { "firstName", $"John_{uid}" },
                { "lastName", $"Doe_{uid}"},
                { "email", $"{uid}@example.com"},
                {
                    "items", new List<object>
                    {
                        new Dictionary<string, object>
                        {
                            { "initialPrice", 500 },
                            { "quantity", 2},
                            { "productId", "_jAjMfjjgs6ukFxOiTE433"},
                            { "productName", "Test"}
                        }
                    }
                }
            };

            Response orderCreateResponse = await _client.OrdersCreate(order);

            Assert.IsTrue(orderCreateResponse.IsSuccessfull());
            Assert.IsTrue(orderCreateResponse.GetStatusCode() == 201);
            Assert.IsInstanceOfType(orderCreateResponse, typeof(Response));
            Assert.IsTrue(orderCreateResponse.GetResponse().ContainsKey("id"));

            Response orderGetResponse = await _client.OrdersGet(orderCreateResponse.GetResponse()["id"].ToString(), "id");

            Assert.IsTrue(orderGetResponse.IsSuccessfull());
            Assert.IsTrue(orderGetResponse.GetStatusCode() == 200);
            Assert.IsInstanceOfType(orderGetResponse, typeof(Response));
            Assert.IsTrue(orderGetResponse.GetResponse().ContainsKey("order"));

            Dictionary<string, object> orderFromResponse =
                (Dictionary<string, object>) orderGetResponse.GetResponse()["order"];

            object[] arr = (object[])orderFromResponse["items"];
            int[] id = new int[1];
            

            foreach (Dictionary<string, object> s in arr.OfType<Dictionary<string, object>>())
            {
                int.TryParse(s["id"].ToString(), NumberStyles.Any, null, out int itemId);
                id[0] = itemId;
            }

            Dictionary<string, object> pack = new Dictionary<string, object>
            {
                { "purchasePrice", 100 },
                { "quantity", 1},
                { "store", Environment.GetEnvironmentVariable("RETAILCRM_STORE")},
                { "itemId", id[0]}
            };

            Response packsCreateResponse = await _client.PacksCreate(pack);

            Debug.WriteLine(packsCreateResponse.GetRawResponse());
            Assert.IsTrue(packsCreateResponse.IsSuccessfull());
            Assert.IsTrue(packsCreateResponse.GetStatusCode() == 201);
            Assert.IsInstanceOfType(packsCreateResponse, typeof(Response));
            Assert.IsTrue(packsCreateResponse.GetResponse().ContainsKey("id"));

            string packId = packsCreateResponse.GetResponse()["id"].ToString();

            Dictionary<string, object> packEdit = new Dictionary<string, object>
            {
                { "id", packId },
                { "quantity", 2}
            };

            Response packsUpdateResponse = await _client.PacksUpdate(packEdit);

            Assert.IsTrue(packsUpdateResponse.IsSuccessfull());
            Assert.IsTrue(packsUpdateResponse.GetStatusCode() == 200);
            Assert.IsInstanceOfType(packsUpdateResponse, typeof(Response));
            Assert.IsTrue(packsUpdateResponse.GetResponse().ContainsKey("id"));

            Response packsGetResponse = await _client.PacksGet(packId);

            Assert.IsTrue(packsGetResponse.IsSuccessfull());
            Assert.IsTrue(packsGetResponse.GetStatusCode() == 200);
            Assert.IsInstanceOfType(packsGetResponse, typeof(Response));
            Assert.IsTrue(packsGetResponse.GetResponse().ContainsKey("pack"));

            Response packsDeleteResponse = await _client.PacksDelete(packId);

            Assert.IsTrue(packsDeleteResponse.IsSuccessfull());
            Assert.IsTrue(packsDeleteResponse.GetStatusCode() == 200);
            Assert.IsInstanceOfType(packsDeleteResponse, typeof(Response));

        }

        [TestMethod]
        public async Task PacksList()
        {
            Dictionary<string, object> filter = new Dictionary<string, object>
            {
                { "store", Environment.GetEnvironmentVariable("RETAILCRM_STORE")}
            };

            Response response = await _client.PacksList(filter, 1, 100);

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("packs"));
        }

        [TestMethod]
        public async Task PacksHistory()
        {
            Dictionary<string, object> filter = new Dictionary<string, object>
            {
                { "endDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
            };

            Response response = await _client.PacksHistory(filter, 2, 100);

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("history"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter `pack` must contains a data")]
        public async Task PacksCreateArgumentExeption()
        {
            Dictionary<string, object> pack = new Dictionary<string, object>();
            await _client.PacksCreate(pack);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter `pack` must contains a data")]
        public async Task PacksUpdateArgumentExeption()
        {
            Dictionary<string, object> pack = new Dictionary<string, object>();
            await _client.PacksUpdate(pack);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Parameter `pack` must contains an id")]
        public async Task PacksUpdateWithoutIdArgumentExeption()
        {
            Dictionary<string, object> pack = new Dictionary<string, object>
            {
                { "quantity", 2 }
            };

            await _client.PacksUpdate(pack);
        }
    }
}
