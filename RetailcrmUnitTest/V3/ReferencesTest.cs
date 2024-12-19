using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retailcrm;
using Retailcrm.Versions.V3;

namespace RetailcrmUnitTest.V3
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
        public async Task Countries()
        {
            Response response = await _client.Countries();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task DeliveryServices()
        {
            Response response = await _client.DeliveryServices();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task DeliveryTypes()
        {
            Response response = await _client.DeliveryTypes();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task OrderMethods()
        {
            Response response = await _client.OrderMethods();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task OrderTypes()
        {
            Response response = await _client.OrderTypes();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task PaymentStatuses()
        {
            Response response = await _client.PaymentStatuses();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task PaymentTypes()
        {
            Response response = await _client.PaymentTypes();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task ProductStatuses()
        {
            Response response = await _client.ProductStatuses();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task Sites()
        {
            Response response = await _client.Sites();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task StatusGroups()
        {
            Response response = await _client.StatusGroups();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task Statuses()
        {
            Response response = await _client.Statuses();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task Stores()
        {
            Response response = await _client.Stores();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task DeliveryServicesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.DeliveryServicesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestDeliveryService-{guid}" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task DeliveryTypesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.DeliveryTypesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestDeliveryType-{guid}" },
                    { "defaultCost", 300 },
                    { "defaultNetCost", 250}
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task OrderMethodsEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response =await _client.OrderMethodsEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestOrderMethod-{guid}" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task OrderTypesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.OrderTypesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestOrderType-{guid}" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task PaymentStatusesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.PaymentStatusesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestPaymentStatus-{guid}" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task PaymentTypesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.PaymentTypesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestPaymentType-{guid}" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task ProductStatusesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.ProductStatusesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestProductStatus-{guid}" }
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task SitesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.SitesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestProductStatus-{guid}" },
                    { "url", $"http://{guid}.example.org" }
                }
            );

            Assert.IsFalse(response.IsSuccessfull());
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task StatusesEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.StatusesEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestProductStatus-{guid}" },
                    { "ordering", 40},
                    { "group", "cancel"}
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task StoresEdit()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);

            Response response = await _client.StoresEdit(
                new Dictionary<string, object>
                {
                    { "code", guid},
                    { "name", $"TestProductStatus-{guid}" },
                    { "type", "store-type-warehouse"}
                }
            );

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200 || response.GetStatusCode() == 201);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }
    }
}