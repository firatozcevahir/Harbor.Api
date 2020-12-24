using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.Models
{
    public class ArtifactAdditionLinks
    {
        [JsonProperty("build_history")]
        public BuildHistory BuildHistory { get; set; }
    }

    public class BuildHistory
    {
        [JsonProperty("absolute")]
        public bool Absolute { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

    }
}
