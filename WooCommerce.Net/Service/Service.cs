using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Newtonsoft.Json;
using WooCommerce.Net.Utils;

namespace WooCommerce.Net.Service
{
    public abstract class Service
    {
        public readonly ApiDriver ApiDriver;

        public Service(ApiDriver apiDriver)
        {
            ApiDriver = apiDriver;
        }

        public T Post<T>(string apiEndpoint, Dictionary<string, string> parameters = null, T toSerialize = default(T))
        {
            var jsonData = JsonConvert.SerializeObject(toSerialize, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var jsonResult = ApiDriver.Post(apiEndpoint, parameters, jsonData);
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public T Put<T>(string apiEndpoint, Dictionary<string, string> parameters = null, T toSerialize = default(T))
        {
            var jsonData = JsonConvert.SerializeObject(toSerialize, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var jsonResult = ApiDriver.Put(apiEndpoint, parameters, jsonData);
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public T Delete<T>(string apiEndpoint, Dictionary<string, string> parameters = null)
        {
            var jsonResult = ApiDriver.Delete(apiEndpoint, parameters);
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public T Get<T>(string apiEndpoint, Dictionary<string, string> parameters = null)
        {
            var jsonResult = ApiDriver.Get(apiEndpoint, parameters);
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }
    }
}