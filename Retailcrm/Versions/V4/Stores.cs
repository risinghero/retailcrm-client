using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V4
{
    public partial class Client
    {
        /// <summary>
        /// Get products
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> StoreProducts(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
        {
            Dictionary<string, object> parameters = [];
            if (filter != null && filter.Count > 0)
                parameters.Add("filter", filter);
            if (page > 0)
                parameters.Add("page", page);
            if (limit > 0)
                parameters.Add("limit", limit);
            return Request.MakeRequest("/store/products", HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Upload prices
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public Task<Response> StorePricesUpload(List<object> prices)
        {
            if (prices.Count< 1)
                throw new ArgumentException("Parameter `prices` must contains a data");
            if (prices.Count > 250)
                throw new ArgumentException("Parameter `prices` must contain 250 or less records");
            return Request.MakeRequest(
                "/store/prices/upload",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "prices", new JavaScriptSerializer().Serialize(prices) }
                }
            );
        }

        /// <summary>
        /// Get store settings
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Response> StoreSettingGet(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("Parameter `code` is mandatory");
            return Request.MakeRequest(
                $"/store/setting/{code}",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Edit store settings
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public Task<Response> StoreSettingsEdit(Dictionary<string, object> configuration)
        {
            if (configuration.Count < 1)
            {
                throw new ArgumentException("Parameter `configuration` must contain data");
            }

            if (!configuration.ContainsKey("clientId"))
            {
                throw new ArgumentException("Parameter `configuration` should contain `clientId`");
            }

            if (!configuration.ContainsKey("baseUrl"))
            {
                throw new ArgumentException("Parameter `configuration` should contain `baseUrl`");
            }

            if (!configuration.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `configuration` should contain `code`");
            }

            if (!configuration.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `configuration` should contain `name`");
            }

            return Request.MakeRequest(
                $"/store/setting/{configuration["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "configuration", new JavaScriptSerializer().Serialize(configuration) }
                }
            );
        }
    }
}
