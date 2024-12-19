using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Retailcrm
{
    /// <summary>
    /// Request
    /// </summary>
    public class Request
    {
        private const string UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        private const string ContentType = "application/x-www-form-urlencoded";

        private readonly string _url;
        private readonly Dictionary<string, object> _defaultParameters;
        private static readonly HttpClient DefaultClient = new(new Http2CustomHandler
        {
            EnableMultipleHttp2Connections = true,
        });
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Request constructor
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="parameters"></param>
        /// <exception cref="ArgumentException"></exception>
        public Request(string apiUrl, Dictionary<string, object> parameters = null)
            : this(DefaultClient, apiUrl, parameters)
        {

        }

        public Request(HttpClient client, string apiUrl, Dictionary<string, object> parameters = null)
        {
            if (apiUrl.IndexOf("https://", StringComparison.Ordinal) == -1)
            {
                throw new ArgumentException("API schema requires HTTPS protocol");
            }
            _httpClient = client;
            _url = apiUrl;
            _defaultParameters = parameters;
        }

        /// <summary>
        /// Make request method
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="WebException"></exception>
        public async Task<Response> MakeRequest(string path, HttpMethod method, Dictionary<string, object> parameters = null)
        {
            if (method != HttpMethod.Get && method != HttpMethod.Post)
                throw new ArgumentException($"Method {method} is not valid. Allowed HTTP methods are GET and POST");
            parameters ??= [];

            parameters = _defaultParameters.Union(parameters).ToDictionary(k => k.Key, v => v.Value);
            path = _url + path;
            string httpQuery = QueryBuilder.BuildQueryString(parameters);
            if (method == HttpMethod.Get && parameters.Count > 0)
                path += "?" + httpQuery;
            using var httpRequest = new HttpRequestMessage(method, path);
            using var content = new StringContent(httpQuery);
            if (method == HttpMethod.Post)
            {
                httpRequest.Content = content;
                httpRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(ContentType);
                httpRequest.Headers.UserAgent.ParseAdd(UserAgent);
            }

            using var response = await _httpClient.SendAsync(httpRequest);
            using StreamReader reader = new(await response.Content.ReadAsStreamAsync());
            string responseBody = reader.ReadToEnd();
            int statusCode = (int)response.StatusCode;
            return new Response(statusCode, responseBody);
        }
    }
}