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
        /// Countries
        /// </summary>
        /// <returns></returns>
        public Task<Response> Countries()
        {
            return Request.MakeRequest(
                "/reference/countries",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Delivery services
        /// </summary>
        /// <returns></returns>
        public Task<Response> DeliveryServices()
        {
            return Request.MakeRequest(
                "/reference/delivery-services",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Delivery types
        /// </summary>
        /// <returns></returns>
        public Task<Response> DeliveryTypes()
        {
            return Request.MakeRequest(
                "/reference/delivery-types",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Order methods
        /// </summary>
        /// <returns></returns>
        public Task<Response> OrderMethods()
        {
            return Request.MakeRequest(
                "/reference/order-methods",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Order types
        /// </summary>
        /// <returns></returns>
        public Task<Response> OrderTypes()
        {
            return Request.MakeRequest(
                "/reference/order-types",
                HttpMethod.Get
            );
        }

        /// <summary>
        /// Payment statuses
        /// </summary>
        /// <returns></returns>
        public Task<Response> PaymentStatuses()
        {
            return Request.MakeRequest("/reference/payment-statuses", HttpMethod.Get);
        }

        /// <summary>
        /// Payment types
        /// </summary>
        /// <returns></returns>
        public Task<Response> PaymentTypes()
        {
            return Request.MakeRequest("/reference/payment-types", HttpMethod.Get);
        }

        /// <summary>
        /// Product statuses
        /// </summary>
        /// <returns></returns>
        public Task<Response> ProductStatuses()
        {
            return Request.MakeRequest("/reference/product-statuses", HttpMethod.Get);
        }

        /// <summary>
        /// Sites
        /// </summary>
        /// <returns></returns>
        public Task<Response> Sites()
        {
            return Request.MakeRequest("/reference/sites", HttpMethod.Get);
        }

        /// <summary>
        /// Statuses groups
        /// </summary>
        /// <returns></returns>
        public Task<Response> StatusGroups()
        {
            return Request.MakeRequest("/reference/status-groups", HttpMethod.Get);
        }

        /// <summary>
        /// Statuses
        /// </summary>
        /// <returns></returns>
        public Task<Response> Statuses()
        {
            return Request.MakeRequest("/reference/statuses", HttpMethod.Get);
        }

        /// <summary>
        /// Stores
        /// </summary>
        /// <returns></returns>
        public Task<Response> Stores()
        {
            return Request.MakeRequest("/reference/stores", HttpMethod.Get);
        }

        /// <summary>
        /// Delivery services edit
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public Task<Response> DeliveryServicesEdit(Dictionary<string, object> service)
        {
            if (!service.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!service.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            return Request.MakeRequest(
                $"/reference/delivery-services/{service["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "deliveryService", new JavaScriptSerializer().Serialize(service) }
                }
            );
        }

        /// <summary>
        /// Delivery types edit
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<Response> DeliveryTypesEdit(Dictionary<string, object> type)
        {
            if (!type.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!type.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            if (!type.ContainsKey("defaultCost"))
            {
                throw new ArgumentException("Parameter `defaultCost` is missing");
            }

            if (!type.ContainsKey("defaultNetCost"))
            {
                throw new ArgumentException("Parameter `defaultCost` is missing");
            }

            return Request.MakeRequest(
                $"/reference/delivery-types/{type["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "deliveryType", new JavaScriptSerializer().Serialize(type) }
                }
            );
        }

        /// <summary>
        /// Orders methods edit
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public Task<Response> OrderMethodsEdit(Dictionary<string, object> method)
        {
            if (!method.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!method.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            return Request.MakeRequest(
                $"/reference/order-methods/{method["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "orderMethod", new JavaScriptSerializer().Serialize(method) }
                }
            );
        }

        /// <summary>
        /// Order types edit
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<Response> OrderTypesEdit(Dictionary<string, object> type)
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
                $"/reference/order-types/{type["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "orderType", new JavaScriptSerializer().Serialize(type) }
                }
            );
        }

        /// <summary>
        /// Payment statuses edit
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public Task<Response> PaymentStatusesEdit(Dictionary<string, object> status)
        {
            if (!status.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!status.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            return Request.MakeRequest(
                $"/reference/payment-statuses/{status["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "paymentStatus", new JavaScriptSerializer().Serialize(status) }
                }
            );
        }

        /// <summary>
        /// Payment types edit
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<Response> PaymentTypesEdit(Dictionary<string, object> type)
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
                $"/reference/payment-types/{type["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "paymentType", new JavaScriptSerializer().Serialize(type) }
                }
            );
        }

        /// <summary>
        /// Product statuses edit
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public Task<Response> ProductStatusesEdit(Dictionary<string, object> status)
        {
            if (!status.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!status.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            return Request.MakeRequest(
                $"/reference/product-statuses/{status["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "productStatus", new JavaScriptSerializer().Serialize(status) }
                }
            );
        }

        /// <summary>
        /// Sites edit
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> SitesEdit(Dictionary<string, object> site)
        {
            if (!site.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!site.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            if (!site.ContainsKey("url"))
            {
                throw new ArgumentException("Parameter `url` is missing");
            }

            return Request.MakeRequest(
                $"/reference/sites/{site["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "site", new JavaScriptSerializer().Serialize(site) }
                }
            );
        }

        /// <summary>
        /// Statuses edit
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public Task<Response> StatusesEdit(Dictionary<string, object> status)
        {
            if (!status.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!status.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }
            
            if (!status.ContainsKey("ordering"))
            {
                throw new ArgumentException("Parameter `ordering` is missing");
            }

            if (!status.ContainsKey("group"))
            {
                throw new ArgumentException("Parameter `group` is missing");
            }

            return Request.MakeRequest(
                $"/reference/statuses/{status["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "status", new JavaScriptSerializer().Serialize(status) }
                }
            );
        }

        /// <summary>
        /// Stores edit
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public Task<Response> StoresEdit(Dictionary<string, object> store)
        {
            if (!store.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!store.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            List<string> types =
            [
                "store-type-online",
                "store-type-retail",
                "store-type-supplier",
                "store-type-warehouse"
            ];

            if (store.ContainsKey("type") && !types.Contains(store["type"].ToString()))
            {
                throw new ArgumentException("Parameter `type` should be equal to one of `store-type-online|store-type-retail|store-type-supplier|store-type-warehouse`");
            }

            return Request.MakeRequest(
                $"/reference/stores/{store["code"]}/edit",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "store", new JavaScriptSerializer().Serialize(store) }
                }
            );
        }
    }
}
