using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retailcrm.Versions.V5
{
    public partial class Client
    {
        /// <summary>
        /// Get external store settings
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public new Task<Response> StoreSettingGet(string code)
        {
            throw new ArgumentException("This method is unavailable in API V5", code);
        }

        /// <summary>
        /// Edit external store settings
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public new Task<Response> StoreSettingsEdit(Dictionary<string, object> configuration)
        {
            throw new ArgumentException("This method is unavailable in API V5");
        }

        /// <summary>
        /// Get products groups
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> StoreProductsGroups(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/store/products-groups", System.Net.Http.HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Get products properties
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> StoreProductsProperties(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/store/products/properties", System.Net.Http.HttpMethod.Get, parameters);
        }
    }
}
