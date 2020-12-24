using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.Models
{
    public class Repository
    {
        [JsonProperty("artifact_count")]
        public int ArtifactCount { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("project_public")]
        public bool ProjectPublic { get; set; }

        [JsonProperty("pull_count")]
        public int PullCount { get; set; }

        [JsonProperty("repository_name")]
        public string RepositoryName { get; set; }
    }
}
