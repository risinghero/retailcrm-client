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
    public class UsersTest
    {
        private readonly Client _client;

        public UsersTest()
        {
            _client = new Client(
               Environment.GetEnvironmentVariable("RETAILCRM_URL"),
               Environment.GetEnvironmentVariable("RETAILCRM_KEY")
           );
        }

        [TestMethod]
        public async Task UsersStatus()
        {
            Response users = await _client.Users();
            Assert.IsTrue(users.IsSuccessfull());
            Assert.IsTrue(users.GetStatusCode() == 200);
            Assert.IsInstanceOfType(users, typeof(Response));
            Assert.IsTrue(users.GetResponse().ContainsKey("success"));

            object[] list = (object[])users.GetResponse()["users"];
            var user = list[0] as Dictionary<string, object>;
            Debug.Assert(user != null, nameof(user) + " != null");
            int uid = int.Parse(user["id"].ToString());
            
            Response status = await _client.UsersStatus(uid, "break");
            Assert.IsTrue(status.IsSuccessfull());
            Assert.IsTrue(status.GetStatusCode() == 200);
            Assert.IsInstanceOfType(status, typeof(Response));
            Assert.IsTrue(status.GetResponse().ContainsKey("success"));
        }
    }
}
