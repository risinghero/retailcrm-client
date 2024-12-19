using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Retailcrm.Versions.V4
{
    public partial class Client
    {
        /// <summary>
        /// Get orders history
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> OrdersHistory(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (filter != null && filter.Count > 0)
            {
                parameters.Add("filter", filter);
            }

            if (page > 0)
            {
                parameters.Add("page", page);
            }

            if (limit > 0)
            {
                parameters.Add("limit", limit);
            }

            return Request.MakeRequest("/orders/history", HttpMethod.Get, parameters);
        }
    }
}
