using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Harbor.Api.Models;
using Harbor.Api.ResponseModels;
using Harbor.Api.Utilities;
using Newtonsoft.Json;

namespace Harbor.Api.Operations
{
    public interface IProjectOperations
    {
        Task<int> CreateProject(ProjectCreateParameters settings, CancellationToken cancellationToken = default(CancellationToken));
        Task<IList<ProjectResponse>> ListProjects(ProjectListParameters settings = null, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default(CancellationToken));
        Task<ProjectResponse> GetProject(long id, CancellationToken cancellationToken = default(CancellationToken));
        Task<IList<LogResponse>> GetProjectLogs(string projectname, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> DeleteProject(int id, CancellationToken cancellationToken = default(CancellationToken));
    }
    public class ProjectOperations: IProjectOperations
    {
        private readonly HarborClient _client;
        public ProjectOperations(HarborClient client)
        {
            _client = client;
        }

        public async Task<IList<ProjectResponse>> ListProjects(ProjectListParameters settings = null, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default)
        {
            if (settings == null) settings = new ProjectListParameters();
            var result = await _client.MakeGetRequestAsync(
                "projects",
                $"page={page}&page_size={pageSize}&name={settings.ProjectName}&public={settings.IsPublic}&owner={settings.Owner}",
                cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<IList<ProjectResponse>>(result.Body);
        }

        public async Task<ProjectResponse> GetProject(long id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _client.MakeGetRequestAsync(
                $"projects/{id}",
                cancellationToken: cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<ProjectResponse>(result.Body);
        }

        public async Task<IList<LogResponse>> GetProjectLogs(string projectname, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default)
        {
            var result = await _client.MakeGetRequestAsync(
                $"projects/{projectname}/logs",
                $"page={page}&page_size={pageSize}",
                cancellationToken).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<IList<LogResponse>>(result.Body);
        }

        public async Task<int> DeleteProject(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _client.MakeDeleteRequestAsync(
                $"projects/{id}", cancellationToken: cancellationToken).ConfigureAwait(false);

            return 1;
        }

        public async Task<int> CreateProject(ProjectCreateParameters settings, CancellationToken cancellationToken = default)
        {
            if(settings == null)
                throw new ArgumentNullException(nameof(settings));

            var result = await _client.MakePostRequestAsync(
                "projects",
                HttpUtility.GetHttpContent(settings));

            return 1;
        }
    }
}
