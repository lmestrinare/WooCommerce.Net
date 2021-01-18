using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WooCommerce.Net.Utils
{

    public class ApiUrlGenerator
    {
        private const string ApiRootEndpoint = "wp-json/wc/v2/";
        private readonly string baseURI;
        private readonly string consumerKey;
        private readonly string consumerSecret;

        public ApiUrlGenerator(string storeUrl, string consumerKey, string consumerSecret)
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

            this.baseURI = String.Format("{0}/{1}", storeUrl.TrimEnd('/'), ApiRootEndpoint);
        }

        public string GenerateRequestUrl(HttpMethod httpMethod, string apiEndpoint, Dictionary<string, string> parameters = null)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            parameters["consumer_key"] = this.consumerKey;
            parameters["consumer_secret"] = this.consumerSecret;

            var sb = new StringBuilder();
            foreach (var pair in parameters)
            {
                sb.AppendFormat("&{0}={1}", pair.Key, pair.Value);
            }

            // Substring removes first '&'
            var queryString = sb.ToString().Substring(1);

            var url = this.baseURI + apiEndpoint + "?" + queryString;

            return url;
        }
    }
}