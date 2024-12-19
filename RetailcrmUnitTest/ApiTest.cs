using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retailcrm;
using System.Threading.Tasks;

namespace RetailcrmUnitTest
{
    [TestClass]
    public class ApiTest
    {
        private readonly Connection _connection;

        public ApiTest()
        {
            _connection = new Connection(
                System.Environment.GetEnvironmentVariable("RETAILCRM_URL"),
                System.Environment.GetEnvironmentVariable("RETAILCRM_KEY")
            );
        }

        [TestMethod]
        public async Task Versions()
        {
            Response response = await _connection.Versions();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("versions"));
        }

        [TestMethod]
        public async Task Credentials()
        {
            Response response = await _connection.Credentials();

            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("credentials"));
        }
    }
}
