using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retailcrm;
using Retailcrm.Versions.V3;

namespace RetailcrmUnitTest.V3
{
    [TestClass]
    public class TelephonyTest
    {
        private readonly Client _client;
        
        public TelephonyTest()
        {
            _client = new Client(
                Environment.GetEnvironmentVariable("RETAILCRM_URL"),
                Environment.GetEnvironmentVariable("RETAILCRM_KEY")
            );
        }

        [TestMethod]
        [Ignore]
        public async Task TelephonyManagerGet()
        {
            Response response =await _client.TelephonyManagerGet("+79999999999");
            Debug.WriteLine(response.GetRawResponse());
            Assert.IsTrue(response.IsSuccessfull());
            Assert.IsTrue(response.GetStatusCode() == 200);
            Assert.IsInstanceOfType(response, typeof(Response));
            Assert.IsTrue(response.GetResponse().ContainsKey("success"));
        }
    }
}
