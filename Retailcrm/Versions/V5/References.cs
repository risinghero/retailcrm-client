using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V5
{
    public partial class Client
    {
        /// <summary>
        /// Costs groups
        /// </summary>
        /// <returns></returns>
        public Task<Response> CostGroups()
        {
            return Request.MakeRequest(
                "/reference/cost-groups",
                System.Net.Http.HttpMethod.Get
            );
        }

        /// <summary>
        /// Costs
        /// </summary>
        /// <returns></returns>
        public Task<Response> CostItems()
        {
            return Request.MakeRequest(
                "/reference/cost-items",
                System.Net.Http.HttpMethod.Get
            );
        }

        /// <summary>
        /// Legal entities
        /// </summary>
        /// <returns></returns>
        public Task<Response> LegalEntities()
        {
            return Request.MakeRequest(
                "/reference/legal-entities",
                System.Net.Http.HttpMethod.Get
            );
        }

        /// <summary>
        /// Cost group edit
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public Task<Response> CostGroupsEdit(Dictionary<string, object> group)
        {
            if (!group.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!group.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            if (!group.ContainsKey("color"))
            {
                throw new ArgumentException("Parameter `color` is missing");
            }

            return Request.MakeRequest(
                $"/reference/cost-groups/{@group["code"]}/edit",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "costGroup", new JavaScriptSerializer().Serialize(group) }
                }
            );
        }

        /// <summary>
        /// Cost items edit
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<Response> CostItemsEdit(Dictionary<string, object> item)
        {
            if (!item.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!item.ContainsKey("name"))
            {
                throw new ArgumentException("Parameter `name` is missing");
            }

            if (!item.ContainsKey("group"))
            {
                throw new ArgumentException("Parameter `group` is missing");
            }

            List<string> types = [
                "const",
                "var"
            ];

            if (item.ContainsKey("type") && !types.Contains(item["type"].ToString()))
            {
                throw new ArgumentException("Parameter `type` should be one of `const|var`");
            }

            return Request.MakeRequest(
                $"/reference/cost-items/{item["code"]}/edit",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "costItem", new JavaScriptSerializer().Serialize(item) }
                }
            );
        }

        /// <summary>
        /// Legal entities edit
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<Response> LegalEntitiesEdit(Dictionary<string, object> entity)
        {
            if (!entity.ContainsKey("code"))
            {
                throw new ArgumentException("Parameter `code` is missing");
            }

            if (!entity.ContainsKey("legalName"))
            {
                throw new ArgumentException("Parameter `legalName` is missing");
            }

            if (!entity.ContainsKey("countryIso"))
            {
                throw new ArgumentException("Parameter `countryIso` is missing");
            }

            if (!entity.ContainsKey("contragentType"))
            {
                throw new ArgumentException("Parameter `contragentType` is missing");
            }

            return Request.MakeRequest(
                $"/reference/legal-entities/{entity["code"]}/edit",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "legalEntity", new JavaScriptSerializer().Serialize(entity) }
                }
            );
        }

        /// <summary>
        /// Couriers list
        /// </summary>
        /// <returns></returns>
        public Task<Response> Couriers()
        {
            return Request.MakeRequest(
                "/reference/couriers",
                System.Net.Http.HttpMethod.Get
            );
        }

        /// <summary>
        /// Create a courier
        /// </summary>
        /// <param name="courier"></param>
        /// <returns></returns>
        public Task<Response> CouriersCreate(Dictionary<string, object> courier)
        {
            return Request.MakeRequest(
                "/reference/couriers/create",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "courier", new JavaScriptSerializer().Serialize(courier) }
                }
            );
        }

        /// <summary>
        /// Edit a courier
        /// </summary>
        /// <param name="courier"></param>
        /// <returns></returns>
        public Task<Response> CouriersEdit(Dictionary<string, object> courier)
        {
            if (!courier.ContainsKey("id"))
            {
                throw new ArgumentException("Parameter `id` is missing");
            }

            return Request.MakeRequest(
                $"/reference/couriers/{courier["id"]}/edit",
                System.Net.Http.HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "courier", new JavaScriptSerializer().Serialize(courier) }
                }
            );
        }
    }
}
