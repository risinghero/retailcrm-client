using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retailcrm;
using Retailcrm.Versions.V4;

namespace RetailcrmUnitTest.V4
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
        public async Task UsersGroups()
        {
            Response usersGroups = await _client.UsersGroups();
            Assert.IsTrue(usersGroups.IsSuccessfull());
            Assert.IsTrue(usersGroups.GetStatusCode() == 200);
            Assert.IsInstanceOfType(usersGroups, typeof(Response));
            Assert.IsTrue(usersGroups.GetResponse().ContainsKey("success"));
        }

        [TestMethod]
        public async Task User()
        {
            Response usersGroups =await _client.User(int.Parse(Environment.GetEnvironmentVariable("RETAILCRM_USER")));
            Assert.IsTrue(usersGroups.IsSuccessfull());
            Assert.IsTrue(usersGroups.GetStatusCode() == 200);
            Assert.IsInstanceOfType(usersGroups, typeof(Response));
            Assert.IsTrue(usersGroups.GetResponse().ContainsKey("success"));
        }
    }
}
