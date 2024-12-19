using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V4
{
    public partial class Client
    {
        /// <summary>
        /// Edit marketplace module settings
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public Task<Response> MarketplaceSettingsEdit(Dictionary<string, object> configuration)
        {
            if (configuration.Count < 1)
            {
                throw new ArgumentException("Parameter `configuration` must contain data");
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
                $"/marketplace/external/setting/{configuration["code"]}/edit",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "configuration", new JavaScriptSerializer().Serialize(configuration) }
                }
            );
        }
    }
}
