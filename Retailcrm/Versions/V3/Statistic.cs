using System.Threading.Tasks;

namespace Retailcrm.Versions.V3
{
    public partial class Client
    {
        /// <summary>
        /// Update statistic
        /// </summary>
        /// <returns></returns>
        public Task<Response> StatisticUpdate()
        {
            return Request.MakeRequest(
                "/statistic/update",
                System.Net.Http.HttpMethod.Get
            );
        }
    }
}
