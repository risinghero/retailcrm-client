﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Retailcrm.Versions.V5
{
    public partial class Client
    {
        /// <summary>
        /// Create note
        /// </summary>
        /// <param name="note"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        public Task<Response> NotesCreate(Dictionary<string, object> note, string site = "")
        {
            if (note.Count < 1)
            {
                throw new ArgumentException("Parameter `note` must contains a data");
            }

            return Request.MakeRequest(
                "/customers/notes/create",
                HttpMethod.Post,
                FillSite(
                    site,
                    new Dictionary<string, object>
                    {
                        { "note", new JavaScriptSerializer().Serialize(note) }
                    }
                )
            );
        }

        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Response> NotesDelete(string id)
        {
            return Request.MakeRequest(
                $"/customers/notes/{id}/delete",
                HttpMethod.Post
            );
        }

        /// <summary>
        /// Get notes list
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public Task<Response> NotesList(Dictionary<string, object> filter = null, int page = 1, int limit = 20)
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

            return Request.MakeRequest("/customers/notes", HttpMethod.Get, parameters);
        }
    }
}
