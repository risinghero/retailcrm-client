﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retailcrm;
using Retailcrm.Versions.V5;

namespace RetailcrmUnitTest.V5
{
    [TestClass]
    public class PaymentsTest
    {
        private readonly Client _client;

        public PaymentsTest()
        {
            _client = new Client(
               Environment.GetEnvironmentVariable("RETAILCRM_URL"),
               Environment.GetEnvironmentVariable("RETAILCRM_KEY")
           );
        }

        [TestMethod]
        public async Task PaymentsCreateUpdateDelete()
        {
            DateTime datetime = DateTime.Now;
            string guid = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 6);
            
            Response createResponse = await _client.OrdersCreate(new Dictionary<string, object>
            {
                {"externalId", guid},
                {"createdAt", datetime.ToString("yyyy-MM-dd HH:mm:ss")},
                {"lastName", "Doe"},
                {"firstName", "John"},
                {"email", "john@example.com"},
                {"phone", "+79999999999"}
            });

            Debug.WriteLine(createResponse.GetRawResponse());
            Assert.IsTrue(createResponse.IsSuccessfull());
            Assert.IsInstanceOfType(createResponse, typeof(Response));
            Assert.IsTrue(createResponse.GetResponse().ContainsKey("id"));

            Response paymentCreateResponse = await _client.PaymentsCreate(
                new Dictionary<string, object>
                {
                    { "externalId", guid },
                    { "type", "cash" },
                    { "comment", "test payment" },
                    { "order", new Dictionary<string, object> { { "id", createResponse.GetResponse()["id"].ToString() } } },
                }
            );

            Debug.WriteLine(paymentCreateResponse.GetRawResponse());
            Assert.IsTrue(paymentCreateResponse.IsSuccessfull());
            Assert.IsTrue(paymentCreateResponse.GetStatusCode() == 201);
            Assert.IsInstanceOfType(paymentCreateResponse, typeof(Response));
            Assert.IsTrue(paymentCreateResponse.GetResponse().ContainsKey("success"));

            Response paymentUpdateResponse = await _client.PaymentsUpdate(
                new Dictionary<string, object>
                {
                    { "id", paymentCreateResponse.GetResponse()["id"].ToString()},
                    { "status", "paid"},
                    { "paidAt", datetime.ToString("yyyy-MM-dd HH:mm:ss")},
                    { "amount", 4000 }
                }
            );

            Debug.WriteLine(paymentUpdateResponse.GetRawResponse());
            Assert.IsTrue(paymentUpdateResponse.IsSuccessfull());
            Assert.IsInstanceOfType(paymentUpdateResponse, typeof(Response));
            Assert.IsTrue(paymentUpdateResponse.GetResponse().ContainsKey("success"));

            Response response = await _client.PaymentsDelete(paymentCreateResponse.GetResponse()["id"].ToString());

            Debug.WriteLine(response.GetRawResponse());
            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }
    }
}
