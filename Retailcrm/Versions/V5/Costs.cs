using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V5
{
    public partial class Client
    {
        /// <summary>
        /// Get costs
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> CostsList(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/costs", HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Create cost
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> CostsCreate(Dictionary<string, object> cost, string site = "")
        {
            if (cost.Count < 1)
            {
                throw new ArgumentException("Parameter `cost` must contains a data");
            }

            if (!cost.ContainsKey("costItem"))
            {
                throw new ArgumentException("Parameter `costItem` must be set");
            }

            if (!cost.ContainsKey("summ"))
            {
                throw new ArgumentException("Parameter `summ` must be set");
            }

            if (!cost.ContainsKey("dateFrom"))
            {
                throw new ArgumentException("`dateFrom`: Time interval lower bound must not be blank");
            }

            if (!cost.ContainsKey("dateTo"))
            {
                throw new ArgumentException("`dateTo`: Time interval upper bound must not be blank");
            }

            return Request.MakeRequest(
                "/costs/create",
                HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "cost", new JavaScriptSerializer().Serialize(cost) }
                    }
                )
            );
        }

        /// <summary>
        /// Delete cost
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<Response> CostsDelete(List<string> ids)
        {
            if (ids.Count < 1)
            {
                throw new ArgumentException("Parameter `ids` must contains a data");
            }

            return Request.MakeRequest(
                "/costs/delete",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "ids", new JavaScriptSerializer().Serialize(ids) }
                }
            );
        }

        /// <summary>
        /// Upload costs
        /// </summary>
        /// <param name="costs"></param>
        /// <returns></returns>
        public Task<Response> CostsUpload(List<object> costs)
        {
            if (costs.Count < 1)
            {
                throw new ArgumentException("Parameter `costs` must contains a data");
            }

            if (costs.Count > 50)
            {
                throw new ArgumentException("Parameter `costs` must contain 50 or less records");
            }

            return Request.MakeRequest(
                "/costs/upload",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "costs", new JavaScriptSerializer().Serialize(costs) }
                }
            );
        }

        /// <summary>
        /// Get cost
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> CostsGet(int id)
        {
            return Request.MakeRequest($"/costs/{id}", HttpMethod.Get);
        }

        /// <summary>
        /// Batch delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> CostsDelete(string id)
        {
            return Request.MakeRequest(
                $"/costs/{id}/delete",
                HttpMethod.Post
            );
        }

        /// <summary>
        /// Update cost
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> CostsUpdate(Dictionary<string, object> cost, string site = "")
        {
            if (cost.Count < 1)
            {
                throw new ArgumentException("Parameter `cost` must contains a data");
            }

            if (!cost.ContainsKey("id"))
            {
                throw new ArgumentException("Parameter `cost` must contains an id");
            }

            return Request.MakeRequest(
                $"/costs/{cost["id"]}/edit",
                HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "cost", new JavaScriptSerializer().Serialize(cost) }
                    }
                )
            );
        }
    }
}
