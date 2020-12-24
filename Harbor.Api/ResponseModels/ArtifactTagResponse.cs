using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.ResponseModels
{
    public class ArtifactTagResponse
    {
        [JsonProperty("repository_id")]
        public int RepositoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("push_time")]
        public DateTime PushTime { get; set; }

        [JsonProperty("pull_time")]
        public DateTime PullTime { get; set; }

        [JsonProperty("signed")]
        public bool Signed { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("immutable")]
        public bool Immutable { get; set; }

        [JsonProperty("artifact_id")]
        public int ArtifactId { get; set; }
    }
}
