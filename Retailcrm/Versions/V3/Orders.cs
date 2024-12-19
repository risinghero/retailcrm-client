using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V3
{
    public partial class Client
    {
        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> OrdersCreate(Dictionary<string, object> order, string site = "")
        {
            if (order.Count < 1)
            {
                throw new ArgumentException("Parameter `order` must contains a data");
            }

            return Request.MakeRequest(
                "/orders/create",
                System.Net.Http.HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "order", new JavaScriptSerializer().Serialize(order) }
                    }
                )
            );
        }

        /// <summary>
        /// Update order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="by"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> OrdersUpdate(Dictionary<string, object> order, string by = "externalId", string site = "")
        {
            if (order.Count < 1)
            {
                throw new ArgumentException("Parameter `order` must contains a data");
            }

            if (!order.ContainsKey("id") && !order.ContainsKey("externalId"))
            {
                throw new ArgumentException("Parameter `order` must contains an id or externalId");
            }

            CheckIdParameter(by);

            string uid = by == "externalId" ? order["externalId"].ToString() : order["id"].ToString();

            return Request.MakeRequest(
                $"/orders/{uid}/edit",
                System.Net.Http.HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "by", by },
                        { "order", new JavaScriptSerializer().Serialize(order) }
                    }
                )
            );
        }

        /// <summary>
        /// Get order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="by"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> OrdersGet(string id, string by = "externalId", string site = "")
        {
            CheckIdParameter(by);

            return Request.MakeRequest(
                $"/orders/{id}",
                System.Net.Http.HttpMethod.Get,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "by", by }
                    }
                )
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> OrdersList(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            if (limit > 20)
            {
                parameters.Add("limit", limit);
            }

            return Request.MakeRequest("/orders", System.Net.Http.HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Fix external ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<Response> OrdersFixExternalIds(Dictionary<string, object>[] ids)
        {
            return Request.MakeRequest(
                "/orders/fix-external-ids",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "orders", new JavaScriptSerializer().Serialize(ids) }
                }
            );
        }

        /// <summary>
        /// Get orders history
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="skipMyChanges"></param>
        /// <returns></returns>
        public Task<Response> OrdersHistory(DateTime? startDate = null, DateTime? endDate = null, int limit = 200, int offset = 0, bool skipMyChanges = true)
        {
            Dictionary<string, object> parameters = [];

            if (startDate != null)
            {
                parameters.Add("startDate", startDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            if (endDate != null)
            {
                parameters.Add("endDate", endDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            if (limit > 0)
            {
                parameters.Add("limit", limit);
            }

            if (offset > 0)
            {
                parameters.Add("offset", offset);
            }

            parameters.Add("skipMyChanges", skipMyChanges);
            
            return Request.MakeRequest(
                "/orders/history",
                System.Net.Http.HttpMethod.Get,
                parameters
            );
        }

        /// <summary>
        /// Get orders statuses
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="externalIds"></param>
        /// <returns></returns>
        public Task<Response> OrdersStatuses(List<string> ids, List<string> externalIds = null)
        {
            Dictionary<string, object> parameters = [];

            if (ids == null && externalIds == null)
            {
                throw new ArgumentException("You must set the array of `ids` or `externalIds`.");
            }

            if (
                ids != null && externalIds != null && ids.Count + externalIds.Count > 500 ||
                ids == null && externalIds != null && externalIds.Count > 500 ||
                ids != null && externalIds == null && ids.Count > 500
            )
            {
                throw new ArgumentException("Too many ids or externalIds. Maximum number of elements is 500");
            }

            if (ids != null && ids.Count > 0)
            {
                parameters.Add("ids", ids);
            }

            if (externalIds != null && externalIds.Count > 0)
            {
                parameters.Add("externalIds", externalIds);
            }

            return Request.MakeRequest(
                "/orders/statuses",
                System.Net.Http.HttpMethod.Get,
                parameters
            );
        }

        /// <summary>
        /// Orders upload
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> OrdersUpload(List<object> orders, string site = "")
        {
            if (orders.Count < 1)
            {
                throw new ArgumentException("Parameter `orders` must contains a data");
            }

            if (orders.Count > 50)
            {
                throw new ArgumentException("Parameter `orders` must contain 50 or less records");
            }

            return Request.MakeRequest(
                "/orders/upload",
                System.Net.Http.HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "orders", new JavaScriptSerializer().Serialize(orders) }
                    }
                )
            );
        }
    }
}
