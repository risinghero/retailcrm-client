﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V3
{
    public partial class Client
    {
        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<Response> CustomersCreate(Dictionary<string, object> customer, string site = "")
        {
            if (customer.Count < 1)
            {
                throw new ArgumentException("Parameter `customer` must contains a data");
            }

            return Request.MakeRequest(
                "/customers/create",
                System.Net.Http.HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "customer", new JavaScriptSerializer().Serialize(customer) }
                    }
                )
            );
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="by"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<Response> CustomersUpdate(Dictionary<string, object> customer, string by = "externalId", string site = "")
        {
            if (customer.Count < 1)
            {
                throw new ArgumentException("Parameter `customer` must contains a data");
            }

            if (!customer.ContainsKey("id") && !customer.ContainsKey("externalId"))
            {
                throw new ArgumentException("Parameter `customer` must contains an id or externalId");
            }

            CheckIdParameter(by);

            string uid = by == "externalId" ? customer["externalId"].ToString() : customer["id"].ToString();

            return Request.MakeRequest(
                $"/customers/{uid}/edit",
                System.Net.Http.HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "by", by },
                        { "customer", new JavaScriptSerializer().Serialize(customer) }
                    }
                )
            );
        }

        /// <summary>
        /// Get customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="by"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> CustomersGet(string id, string by = "externalId", string site = "")
        {
            CheckIdParameter(by);

            return Request.MakeRequest(
                $"/customers/{id}",
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
        /// Get customers list
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> CustomersList(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
        {
            Dictionary<string, object> parameters = [];

            if (filter != null && filter.Count > 0)
               parameters.Add("filter", filter);

            if (page > 0)
                parameters.Add("page", page);
            if (limit > 0)
                parameters.Add("limit", limit);
            return Request.MakeRequest("/customers", System.Net.Http.HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Fix external id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<Response> CustomersFixExternalIds(Dictionary<string, object>[] ids)
        {
            return Request.MakeRequest(
                "/customers/fix-external-ids",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "customers", new JavaScriptSerializer().Serialize(ids) }
                }
            );
        }

        /// <summary>
        /// Upload customers
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<Response> CustomersUpload(List<object> customers, string site = "")
        {
            if (customers.Count < 1)
                throw new ArgumentException("Parameter `customers` must contains a data");
            if (customers.Count > 50)
                throw new ArgumentException("Parameter `customers` must contain 50 or less records");
            return Request.MakeRequest(
                "/customers/upload",
                System.Net.Http.HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "customers", new JavaScriptSerializer().Serialize(customers) }
                    }
                )
            );
        }
    }
}
