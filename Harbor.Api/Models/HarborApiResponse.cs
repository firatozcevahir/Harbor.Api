using System.Net;

namespace Harbor.Api.Models
{
    public class HarborApiResponse
    {
        public HttpStatusCode StatusCode { get; private set; }

        public string Body { get; private set; }

        public HarborApiResponse(HttpStatusCode statusCode, string body)
        {
            StatusCode = statusCode;
            Body = body;
        }
    }
}
