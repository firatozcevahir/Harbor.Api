using Harbor.Api.Models;
using Harbor.Api.Operations;
using Harbor.Api.Utilities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Harbor.Api
{
    public class HarborClient : IHarborClient
    {
        public HarborClientConfiguration Configuration { get; }
        public IProductOperations Products { get; }
        public IRepositoryOperations Repositories { get; }
        public IArtifactOperations Artifacts { get; }
        public IProjectOperations Projects { get; }
        public IAuditLogOperations AuditLogs { get; }


        private readonly HttpClient _client;
        // internal JsonSerializer JsonSerializer { get; }

        public HarborClient(HarborClientConfiguration configuration)
        {
            Configuration = configuration;
            // JsonSerializer = new JsonSerializer();

            Products = new ProtuctOperations(this);
            Repositories = new RepositoryOperations(this);
            Artifacts = new ArtifactOperations(this);
            Projects = new ProjectOperations(this);
            AuditLogs = new AuditLogOperations(this);

            _client = new HttpClient(new HttpClientHandler { UseCookies = false });
            _client.DefaultRequestHeaders.Add("accept", "application/json");
            _client.DefaultRequestHeaders.Add("authorization", $"Basic {Base64Encoder.Encode(configuration.Credentials)}");
        }

        internal async Task<HarborApiResponse> MakeGetRequestAsync(string path, string query = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = HttpUtility.BuildUri(Configuration.RegistryUri, path, query);
            try
            {
                var response = await _client.GetAsync(uri).ConfigureAwait(false);
                using (response)
                {
                    await HandleIfErrorResponseAsync(response.StatusCode, response);

                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return new HarborApiResponse(response.StatusCode, responseBody);
                }
            }
            catch (Exception ex)
            {
                throw new HarborApiException(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        internal async Task<HarborApiResponse> MakeDeleteRequestAsync(string path, string query = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = HttpUtility.BuildUri(Configuration.RegistryUri, path, query);
            try
            {
                var response = await _client.DeleteAsync(uri).ConfigureAwait(false);
                using (response)
                {
                    await HandleIfErrorResponseAsync(response.StatusCode, response);

                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return new HarborApiResponse(response.StatusCode, responseBody);
                }
            }
            catch (Exception ex)
            {
                throw new HarborApiException(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        internal async Task<HarborApiResponse> MakePostRequestAsync(string path, HttpContent content, string query = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var uri = HttpUtility.BuildUri(Configuration.RegistryUri, path, query);
            try
            {
                var response = await _client.PostAsync(uri, content);
                using (response)
                {
                    await HandleIfErrorResponseAsync(response.StatusCode, response);

                    var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return new HarborApiResponse(response.StatusCode, responseBody);
                }
            }
            catch (Exception ex)
            {
                throw new HarborApiException(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private async Task HandleIfErrorResponseAsync(HttpStatusCode statusCode, HttpResponseMessage response)
        {
            bool isErrorResponse = statusCode < HttpStatusCode.OK || statusCode >= HttpStatusCode.BadRequest;
            if (isErrorResponse)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new HarborApiException(statusCode, responseBody);
            }
        }
    }
}
