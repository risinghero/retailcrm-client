using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Retailcrm.Versions.V4
{
    public partial class Client
    {
        /// <summary>
        /// Get users
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> Users(Dictionary<string, object> filter = null, int page = 0, int limit = 0)
        {
            Dictionary<string, object> parameters = [];

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

            return Request.MakeRequest("/users", HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Get users groups
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> UsersGroups(int page = 1, int limit = 20)
        {
            Dictionary<string, object> parameters = [];

            if (page > 0)
            {
                parameters.Add("page", page);
            }

            if (limit > 0)
            {
                parameters.Add("limit", limit);
            }

            return Request.MakeRequest("/user-groups", HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Get user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> User(int id)
        {
            return Request.MakeRequest($"/users/{id}", HttpMethod.Get);
        }
    }
}
