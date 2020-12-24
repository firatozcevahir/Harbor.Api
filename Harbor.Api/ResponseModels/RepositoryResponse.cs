using Newtonsoft.Json;
using System;

namespace Harbor.Api.ResponseModels
{
    public class RepositoryResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("artifact_count")]
        public int ArtifactCount { get; set; }

        [JsonProperty("pull_count")]
        public int PullCount { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}
