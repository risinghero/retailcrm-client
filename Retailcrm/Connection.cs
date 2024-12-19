using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retailcrm
{
    /// <summary>
    /// Unversioned API Client
    /// </summary>
    public class Connection
    {
        private readonly Request _request;

        /// <summary>
        /// Unversioned API Client Constructor
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        public Connection(string url, string key)
        {
            if ("/" != url.Substring(url.Length - 1, 1))
                url += "/";
            url += "api/";
            _request = new Request(url, new Dictionary<string, object> { { "apiKey", key } });
        }

        /// <summary>
        /// Get available API versions
        /// </summary>
        /// <returns></returns>
        public Task<Response> Versions()
        {
            return _request.MakeRequest(
                "api-versions",
                System.Net.Http.HttpMethod.Get
            );
        }

        /// <summary>
        /// Get available API methods
        /// </summary>
        /// <returns></returns>
        public Task<Response> Credentials()
        {
            return _request.MakeRequest(
                "credentials",
                System.Net.Http.HttpMethod.Get
            );
        }
    }
}
