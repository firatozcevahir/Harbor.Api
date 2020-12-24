using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Harbor.Api.Models;
using Harbor.Api.ResponseModels;
using Newtonsoft.Json;

namespace Harbor.Api.Operations
{
    public interface IRepositoryOperations
    {
        Task<IList<RepositoryResponse>> ListRepositories(string projectname, int page = 1, long pageSize = 100, CancellationToken cancellationToken = default(CancellationToken));
        Task<RepositoryResponse> GetRepository(string projectname, string reponame, CancellationToken cancellationToken = default(CancellationToken));

        Task<int> DeleteRepository(string projectname, string reponame, CancellationToken cancellationToken = default(CancellationToken));
    }
    public class RepositoryOperations : IRepositoryOperations
    {
        private readonly HarborClient _client;
        public RepositoryOperations(HarborClient client)
        {
            _client = client;
        }

        public async Task<IList<RepositoryResponse>> ListRepositories(string projectname, int page = 1, long pageSize = 100, CancellationToken cancellationToken = default)
        {
            if (pageSize > 100) pageSize = 100;
            var result = await _client.MakeGetRequestAsync(
                $"projects/{projectname}/repositories",
                $"page={page}&page_size={pageSize}",
                cancellationToken: cancellationToken).ConfigureAwait(false);

           return JsonConvert.DeserializeObject<IList<RepositoryResponse>>(result.Body);
        }

        public async Task<RepositoryResponse> GetRepository(string projectname, string reponame, CancellationToken cancellationToken = default)
        {
           
            var result = await _client.MakeGetRequestAsync(
                $"projects/{projectname}/repositories/{reponame}",
                cancellationToken: cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<RepositoryResponse>(result.Body);            
        }

        public async Task<int> DeleteRepository(string projectname, string reponame, CancellationToken cancellationToken = default)
        {
            var result = await _client.MakeDeleteRequestAsync(
                $"/projects/{projectname}/repositories/{reponame}",
                cancellationToken: cancellationToken).ConfigureAwait(false);

            return 1;
        }
    }
}
