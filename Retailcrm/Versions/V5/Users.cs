using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Retailcrm.Versions.V5
{
    public partial class Client
    {
        /// <summary>
        /// Update user status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Task<Response> UsersStatus(int id, string status)
        {
            List<string> statuses = [ "free", "busy", "dinner", "break"];

            if (!statuses.Contains(status))
            {
                throw new ArgumentException("Parameter `status` must be equal one of these values: `free|busy|dinner|break`");
            }

            return Request.MakeRequest(
                $"/users/{id}/status",
                HttpMethod.Post,
                new Dictionary<string, object>
                {
                    { "status", status }
                }
            );
        }
    }
}
