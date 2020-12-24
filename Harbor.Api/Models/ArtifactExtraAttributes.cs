using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace Harbor.Api.Models
{
    public class ArtifactExtraAttributes
    {
        [JsonProperty("architecture")]
        public string Architecture { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("os")]
        public string Os { get; set; }

    }
}
