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
        /// Get custom fields
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> CustomFieldsList(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/custom-fields", HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Create custom field
        /// </summary>
        /// <param name="customField"></param>
        /// <returns></returns>
        public Task<Response> CustomFieldsCreate(Dictionary<string, object> customField)
        {
            List<string> types =
            [
                "boolean", "date", "dictionary", "email", "integer", "numeric", "string", "text"
            ];

            if (customField.Count < 1)
            {
                throw new ArgumentException("Parameter `customField` must contains a data");
            }

            if (!customField.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `customField` should contain `code`");
            }

            if (!customField.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `customField` should contain `name`");
            }

            if (!customField.ContainsKey("type"))
            {
                throw new ArgumentException("Parameter `customField` should contain `type`");
            }

            if (!customField.ContainsKey("entity"))
            {
                throw new ArgumentException("Parameter `customField` should contain `entity`");
            }

            if (!types.Contains(customField["type"].ToString()))
            {
                throw new ArgumentException(
                    "Parameter `customField` should contain `type` & value of type should be on of `boolean|date|dictionary|email|integer|numeric|string|text`"
                );
            }

            return Request.MakeRequest(
                $"/custom-fields/{customField["entity"]}/create",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "customField", new JavaScriptSerializer().Serialize(customField) }
                }
            );
        }

        /// <summary>
        /// Get custom field
        /// </summary>
        /// <param name="code"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<Response> CustomFieldsGet(string code, string entity)
        {
            return Request.MakeRequest(
                $"/custom-fields/{entity}/{code}",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Update custom field
        /// </summary>
        /// <param name="customField"></param>
        /// <returns></returns>
        public Task<Response> CustomFieldsUpdate(Dictionary<string, object> customField)
        {
            if (customField.Count < 1)
            {
                throw new ArgumentException("Parameter `customField` must contains a data");
            }

            if (!customField.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `customField` should contain `code`");
            }

            if (!customField.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `customField` should contain `name`");
            }

            return Request.MakeRequest(
                $"/custom-fields/{customField["entity"]}/{customField["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "customField", new JavaScriptSerializer().Serialize(customField) }
                }
            );
        }

        /// <summary>
        /// Get custom dictionaries
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> CustomDictionaryList(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/custom-fields/dictionaries", HttpMethod.Get, parameters);
        }

        /// <summary>
        /// Create custom dictionary
        /// </summary>
        /// <param name="customDictionary"></param>
        /// <returns></returns>
        public Task<Response> CustomDictionaryCreate(Dictionary<string, object> customDictionary)
        {
            if (customDictionary.Count < 1)
            {
                throw new ArgumentException("Parameter `customDictionary` must contains a data");
            }

            if (!customDictionary.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `customDictionary` should contain `code`");
            }

            if (!customDictionary.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `customDictionary` should contain `name`");
            }

            return Request.MakeRequest(
                "/custom-fields/dictionaries/create",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "customDictionary", new JavaScriptSerializer().Serialize(customDictionary) }
                }
            );
        }

        /// <summary>
        /// Get custom dictionary
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Response> CustomDictionaryGet(string code)
        {
            return Request.MakeRequest(
                $"/custom-fields/dictionaries/{code}",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Update custom dictionary
        /// </summary>
        /// <param name="customDictionary"></param>
        /// <returns></returns>
        public Task<Response> CustomDictionaryUpdate(Dictionary<string, object> customDictionary)
        {
            if (customDictionary.Count < 1)
            {
                throw new ArgumentException("Parameter `customDictionary` must contains a data");
            }

            if (!customDictionary.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `customDictionary` should contain `code`");
            }

            if (!customDictionary.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `customDictionary` should contain `name`");
            }

            return Request.MakeRequest(
                $"/custom-fields/dictionaries/{customDictionary["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "customDictionary", new JavaScriptSerializer().Serialize(customDictionary) }
                }
            );
        }
    }
}
