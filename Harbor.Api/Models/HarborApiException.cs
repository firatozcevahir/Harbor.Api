using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Harbor.Api.Models
{
    public class HarborApiException: Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public string ResponseBody { get; private set; }

        public HarborApiException(HttpStatusCode statusCode, string responseBody)
            : base($"Harbor API responded with status code={statusCode}, response={responseBody}")
        {
            this.StatusCode = statusCode;
            this.ResponseBody = responseBody;
        }
    }
}
