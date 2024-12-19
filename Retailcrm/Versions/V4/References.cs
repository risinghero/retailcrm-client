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
        /// Price types
        /// </summary>
        /// <returns></returns>
        public Task<Response> PriceTypes()
        {
            return Request.MakeRequest(
                "/reference/price-types",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Price type edit
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<Response> PriceTypesEdit(Dictionary<string, object> type)
        {
            if (!type.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!type.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            return Request.MakeRequest(
                $"/reference/price-types/{type["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "priceType", new JavaScriptSerializer().Serialize(type) }
                }
            );
        }
    }
}
