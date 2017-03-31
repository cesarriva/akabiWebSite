using AkaBIWebSite.Contracts.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AkaBIWebSite.Services
{
    public class ApiService : IApiService
    {
        /// <summary>
        /// Gets the response from a API call
        /// </summary>
        /// <param name="urlBase">Base URl for the Web API</param>
        /// <param name="url">URL for the Web API method</param>
        /// <returns>Exposed data</returns>
        public HttpResponseMessage GetResponse(string urlBase, string url)
        {
            using (var client = GetHttpClientFor(urlBase))
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
            }

            return null;
        }

        private HttpClient GetHttpClientFor(string urlBase)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
