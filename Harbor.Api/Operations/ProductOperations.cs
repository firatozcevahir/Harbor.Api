using Harbor.Api.Models;
using Harbor.Api.ResponseModels;
using Harbor.Api.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Harbor.Api.Operations
{
    public interface IProductOperations
    {
        Task<ProductSearchResponse> SearchProductsAsync(string term, CancellationToken cancellationToken = default(CancellationToken));
        Task<IList<UserSearchResponse>> SearchUsersByName(string term, int page = 1, long pageSize = 500, CancellationToken cancellationToken = default(CancellationToken));
        Task<UserInfoResponse> GetCurrentUserInfo(CancellationToken cancellationToken = default(CancellationToken));
        Task<IList<CurrentUserPermissionResponse>> GetCurrentUserPermissions(string scope = "", bool relative = false, CancellationToken cancellationToken = default(CancellationToken));
        Task<UserInfoResponse> GetUserById(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task<SystemInfoResponse> GetSystemInfo(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> CreateLabel(LabelCreateParameters settings, CancellationToken cancellationToken = default(CancellationToken));
    }

    internal class ProtuctOperations : IProductOperations
    {
        private readonly HarborClient _client;
        public ProtuctOperations(HarborClient client)
        {
            _client = client;
        }

        public async Task<ProductSearchResponse> SearchProductsAsync(string term, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _client.MakeGetRequestAsync("search", $"q={term}", cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<ProductSearchResponse>(result.Body);
        }

        public async Task<IList<UserSearchResponse>> SearchUsersByName(string term, int page = 1, long pageSize = 500, CancellationToken cancellationToken = default)
        {
            var result = await _client.MakeGetRequestAsync(
                "users/search",
                $"username={term}&page={page}&page_size={pageSize}",
                cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<IList<UserSearchResponse>>(result.Body);
        }

        public async Task<UserInfoResponse> GetCurrentUserInfo(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _client.MakeGetRequestAsync(
                "users/current",
                cancellationToken: cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<UserInfoResponse>(result.Body);
        }

        public async Task<IList<CurrentUserPermissionResponse>> GetCurrentUserPermissions(string scope = "", bool relative = false, CancellationToken cancellationToken = default)
        {
            var result = await _client.MakeGetRequestAsync(
                "users/current/permissions",
                $"scope={scope}&relative={relative}",
                cancellationToken: cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<IList<CurrentUserPermissionResponse>>(result.Body);
        }

        public async Task<UserInfoResponse> GetUserById(int id, CancellationToken cancellationToken = default)
        {
            var result = await _client.MakeGetRequestAsync(
                $"users/{id}",
                cancellationToken: cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<UserInfoResponse>(result.Body);
        }

        public async Task<SystemInfoResponse> GetSystemInfo(CancellationToken cancellationToken = default)
        {
            var result = await _client.MakeGetRequestAsync(
                $"systeminfo",
                cancellationToken: cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<SystemInfoResponse>(result.Body);
        }

        public async Task<int> CreateLabel(LabelCreateParameters settings, CancellationToken cancellationToken = default(CancellationToken))
        {
            if(settings == null)
                throw new ArgumentNullException(nameof(settings));

            var result = await _client.MakePostRequestAsync(
               "labels",
                HttpUtility.GetHttpContent(settings)).ConfigureAwait(false);

            return 1;
        }
    }
}
