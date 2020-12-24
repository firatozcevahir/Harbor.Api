using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Harbor.Api.Utilities
{
    internal static class HttpUtility
    {
        private static readonly string apiPath = "api/v2.0";
        public static Uri BuildUri(Uri baseUri, string path, string queryString)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException(nameof(baseUri));
            }

            var builder = new UriBuilder(baseUri);

            if (!string.IsNullOrEmpty(apiPath))
            {
                builder.Path += $"{apiPath}/";
            }

            if (!string.IsNullOrEmpty(path))
            {
                builder.Path += $"{path}/";
            }

            if (queryString != null)
            {
                builder.Query = queryString;
            }

            return builder.Uri;
        }

        public static HttpContent GetHttpContent<T>(T settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            return data;
        }
    }
}
