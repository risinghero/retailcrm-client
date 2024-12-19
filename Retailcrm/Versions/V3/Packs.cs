using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V3
{
    public partial class Client
    {
        /// <summary>
        /// Get packs list
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> PacksList(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/orders/packs", System.Net.Http.HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Create pack
        /// </summary>
        /// <param name="pack"></param>
        /// <returns></returns>
        public Task<Response> PacksCreate(Dictionary<string, object> pack)
        {
            if (pack.Count < 1)
            {
                throw new ArgumentException("Parameter `pack` must contains a data");
            }

            return Request.MakeRequest(
                "/orders/packs/create",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "pack", new JavaScriptSerializer().Serialize(pack) }
                }
            );
        }

        /// <summary>
        /// Update pack data
        /// </summary>
        /// <param name="pack"></param>
        /// <returns></returns>
        public Task<Response> PacksUpdate(Dictionary<string, object> pack)
        {
            if (pack.Count < 1)
            {
                throw new ArgumentException("Parameter `pack` must contains a data");
            }

            if (!pack.ContainsKey("id"))
            {
                throw new ArgumentException("Parameter `pack` must contains an id");
            }

            return Request.MakeRequest(
                $"/orders/packs/{pack["id"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "pack", new JavaScriptSerializer().Serialize(pack) }
                }
            );
        }

        /// <summary>
        /// Delete pack
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> PacksDelete(string id)
        {
            return Request.MakeRequest(
                $"/orders/packs/{id}/delete",
                HttpMethod.Post
            );
        }

        /// <summary>
        /// Get pack by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> PacksGet(string id)
        {
            return Request.MakeRequest(
                $"/orders/packs/{id}",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Get packs history
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> PacksHistory(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (filter != null && filter.Count > 0)
            {
                parameters.Add("filter", filter);
            }

            if (page > 1)
            {
                parameters.Add("page", page);
            }

            if (limit > 0)
            {
                parameters.Add("limit", limit);
            }

            return Request.MakeRequest("/orders/packs/history", HttpMethod.Get, parameters);
        }
    }
}
