using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Harbor.Api.Models;
using Harbor.Api.ResponseModels;
using Newtonsoft.Json;

namespace Harbor.Api.Operations
{
    public interface IArtifactOperations
    {
        Task<IList<ArtifactResponse>> ListArtifacts(ArtifactListParameters settings, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<ArtifactTagResponse>> GetTags(TagListParameters settings, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default(CancellationToken));
    }
    public class ArtifactOperations : IArtifactOperations
    {
        private readonly HarborClient _client;
        public ArtifactOperations(HarborClient client)
        {
            _client = client;
        }


        public async Task<IList<ArtifactResponse>> ListArtifacts(ArtifactListParameters settings, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default)
        {
            if (settings == null)
                throw new ArgumentNullException();

            var result = await _client.MakeGetRequestAsync(
                $"projects/{settings.ProjectName}/repositories/{settings.RepositoryName}/artifacts",
                $"page={page}&page_size={pageSize}&with_tag={settings.WithTag}&with_label={settings.WithLabel}&with_scan_overview={settings.WithScanOverview}&with_signature={settings.WithSignature}&with_immutable_status={settings.WithImmutableStatus}",
                cancellationToken: cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IList<ArtifactResponse>>(result.Body);
        }

        public async Task<IList<ArtifactTagResponse>> GetTags(TagListParameters settings, int page = 1, int pageSize = 100, CancellationToken cancellationToken = default)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var result = await _client.MakeGetRequestAsync(
                $"projects/{settings.ProjectName}/repositories/{settings.RepositoryName}/artifacts/{settings.Reference}/tags",
                $"page={page}&page_size={pageSize}&with_signature={settings.WithSignature}&with_immutable_status={settings.WithImmutableStatus}",
                cancellationToken: cancellationToken).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<IList<ArtifactTagResponse>>(result.Body);
        }
    }
}
