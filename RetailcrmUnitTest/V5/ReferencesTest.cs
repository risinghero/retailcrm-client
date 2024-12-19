using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retailcrm;
using Retailcrm.Versions.V5;

namespace RetailcrmUnitTest.V5
{
    [TestClass]
    public class ReferencesTest
    {
        private readonly Client _client;

        public ReferencesTest()
        {
            _client = new Client(
               Environment.GetEnvironmentVariable("RETAILCRM_URL"),
               Environment.GetEnvironmentVariable("RETAILCRM_KEY")
           );
        }

        [TestMethod]
        public async Task CostGroups()
        {
            Response response = await _client.CostGroups();
            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("costGroups"));
        }

        [TestMethod]
        public async Task CostItems()
        {
            Response response = await _client.CostItems();
            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("costItems"));
        }

        [TestMethod]
        public async Task LegalEntities()
        {
            Response response = await _client.LegalEntities();
            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("legalEntities"));
        }

        [TestMethod]
        public async Task CostGroupsEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);
            Response response = await _client.CostGroupsEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestCostGroup-{guid}" },
                    { "color", "#dd4040" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task CostItemsEdit()
        {
            string groupGuid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response groupResponse = await _client.CostGroupsEdit(
                new Dictionary<string, object>
                {
                    { "code", groupGuid},
                    { "name", $"TestCostGroup-{groupGuid}" },
                    { "color", "#60b29a" }
                }
            );

            Assert.IsTrue(groupResponse.IsSuccessfull());
            Assert.IsTrue(groupResponse.GetStatusCode() == 200 || groupResponse.GetStatusCode() == 201);
            Assert.IsInstanceOfType(groupResponse, typeof(Response));
            Assert.IsTrue(groupResponse.GetResponse().ContainsKey("success"));

            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.CostItemsEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "group", groupGuid },
                    { "name", $"TestCostItem-{guid}" },
                    { "type", "const" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task LegalEntitiesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.LegalEntitiesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "legalName", $"Test LegalEntity-{guid}" },
                    { "contragentType", "legal-entity"},
                    { "countryIso", "RU"}
                }
            );

            Debug.WriteLine(response.GetRawResponse());

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task Couriers()
        {
            Response response = await _client.Couriers();
            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("couriers"));
        }

        [TestMethod]
        public async Task CouriersCreate()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 3);

            Response response = await _client.CouriersCreate(
                new Dictionary<string, object>
                {
                    { "firstName", $"CourierFirstName-{guid}"},
                    { "lastName", $"CourierLastName-{guid}" },
                    { "active", false},
                    { "email", $"{guid}@example.com"}
                }
            );

            Debug.WriteLine(response.GetRawResponse());

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task CouriersEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 3);

            Response response = await _client.CouriersCreate(
                new Dictionary<string, object>
                {
                    { "firstName", $"CourierFirstName-{guid}"},
                    { "lastName", $"CourierLastName-{guid}" },
                    { "active", false},
                    { "email", $"{guid}@example.com"}
                }
            );

            Debug.WriteLine(response.GetRawResponse());

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));

            string id = response.GetResponse()["id"].ToString();

            Response responseEdit = await _client.CouriersEdit(
                new Dictionary<string, object>
                {
                    { "id", id},
                    { "firstName", "CourierFirstName"},
                    { "lastName", "CourierLastName" },
                    { "active", true}
                }
            );

            Debug.WriteLine(responseEdit.GetRawResponse());

            Assert.IsTrue(responseEdit.IsSuccessfull());
            Assert.IsTrue(responseEdit.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }
    }
}
