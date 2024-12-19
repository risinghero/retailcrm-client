﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V4
{
    public partial class Client
    {
        /// <summary>
        /// Get delivery settings
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Response> DeliverySettingGet(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException("Parameter `code` is mandatory");
            }

            return Request.MakeRequest(
                $"/delivery/generic/setting/{code}",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Edit delivery settings
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public Task<Response> DeliverySettingsEdit(Dictionary<string, object> configuration)
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
                $"/delivery/generic/setting/{configuration["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "configuration", new JavaScriptSerializer().Serialize(configuration) }
                }
            );
        }

        /// <summary>
        /// Update delivery tracking
        /// </summary>
        /// <param name="code"></param>
        /// <param name="statusUpdate"></param>
        /// <returns></returns>
        public Task<Response> DeliveryTracking(string code, List<object> statusUpdate)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException("Parameter `code` is mandatory");
            }

            if (statusUpdate.Count < 1)
            {
                throw new ArgumentException("Parameter `statusUpdate` must contain data");
            }

            return Request.MakeRequest(
                $"delivery/generic/{code}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "statusUpdate", new JavaScriptSerializer().Serialize(statusUpdate) }
                }
            );
        }
    }
}
