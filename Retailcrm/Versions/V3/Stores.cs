﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V3
{
    public partial class Client
    {
        /// <summary>
        /// Get inventories
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> StoreInventoriesGet(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/store/inventories", System.Net.Http.HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Upload inventories
        /// </summary>
        /// <param name="offers"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> StoreInventoriesUpload(List<object> offers, string site = "")
        {
            if (offers.Count< 1)
            {
                throw new ArgumentException("Parameter `offers` must contains a data");
            }

            if (offers.Count > 250)
            {
                throw new ArgumentException("Parameter `offers` must contain 250 or less records");
            }

            return Request.MakeRequest(
                "/store/inventories/upload",
                System.Net.Http.HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "offers", new JavaScriptSerializer().Serialize(offers) }
                    }
                )
            );
        }
    }
}
