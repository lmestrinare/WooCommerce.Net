using System;
using System.Collections.Generic;
using System.Net;

namespace WooCommerce.Net.Utils
{
    public class ApiDriver
    {
        private readonly ApiUrlGenerator urlGenerator;
        private readonly string consumerKey;
        private readonly string consumerSecret;

        public ApiDriver(string storeUrl, string consumerKey, string consumerSecret)
        {
            if (
                string.IsNullOrEmpty(consumerKey) ||
                string.IsNullOrEmpty(consumerSecret) ||
                string.IsNullOrEmpty(storeUrl))
            {
                throw new ArgumentException("ConsumerKey, consumerSecret and storeUrl are required");
            }

            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;

            this.urlGenerator = new ApiUrlGenerator(storeUrl, consumerKey, consumerSecret);
        }

        public string Delete(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return this.MakeApiUploadStringCall(HttpMethod.Delete, apiEndpoint, parameters, jsonData);
        }

        public string Post(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return this.MakeApiUploadStringCall(HttpMethod.Post, apiEndpoint, parameters, jsonData);
        }

        public string Put(string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            return this.MakeApiUploadStringCall(HttpMethod.Put, apiEndpoint, parameters, jsonData);
        }

        public string Get(string apiEndpoint, Dictionary<string, string> parameters = null)
        {
            return this.MakeApiDownloadStringCall(apiEndpoint, parameters);
        }

        // Basis for GET
        private string MakeApiDownloadStringCall(string apiEndpoint, Dictionary<string, string> parameters = null)
        {
            var url = this.urlGenerator.GenerateRequestUrl(HttpMethod.Get, apiEndpoint, parameters);
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }

        // Basis for PUT, POST, and DELETE
        private string MakeApiUploadStringCall(HttpMethod httpMethod, string apiEndpoint, Dictionary<string, string> parameters = null, string jsonData = null)
        {
            var url = this.urlGenerator.GenerateRequestUrl(httpMethod, apiEndpoint, parameters);
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                return webClient.UploadString(url, httpMethod.ToString().ToUpper(), jsonData ?? String.Empty);
            }
        }
    }
}