using System;
using Newtonsoft.Json;
using Harbor.Api.Models;
using System.Collections.Generic;

namespace Harbor.Api.ResponseModels
{
    public class ArtifactResponse
    {
        [JsonProperty("addition_links")]
        public ArtifactAdditionLinks AdditionLinks { get; set; }

        [JsonProperty("digest")]
        public string Digest { get; set; }

        [JsonProperty("extra_attrs")]
        public ArtifactExtraAttributes ExtraAttributes { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("labels")]
        public IList<ArtifactLabel> Labels { get; set; }

        [JsonProperty("manifest_media_type")]
        public string ManifestMediaType { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("pull_time")]
        public DateTime PullTime { get; set; }

        [JsonProperty("push_time")]
        public DateTime PushTime { get; set; }

        [JsonProperty("references")]
        public IList<ArtifactReference> References { get; set; }

        [JsonProperty("repository_id")]
        public int RepositoryId { get; set; }

        [JsonProperty("size")]
        public ulong Size { get; set; }

        [JsonProperty("tags")]
        public IList<ArtifactTagResponse> Tags { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
