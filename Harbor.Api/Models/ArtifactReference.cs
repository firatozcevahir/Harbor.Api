using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.Models
{
    public class ArtifactReference
    {
        [JsonProperty("platform")]
        public Platform PLatform { get; set; }

        [JsonProperty("child_digest")]
        public string ChildDigest { get; set; }

        [JsonProperty("urls")]
        public string[] Urls { get; set; }

        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        [JsonProperty("child_id")]
        public int ChildId { get; set; }

        [JsonProperty("annotations")]
        public object Annotations { get; set; }
    }

    public class Platform
    {
        [JsonProperty("os")]
        public string Os { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }

        [JsonProperty("architecture")]
        public string Architecture { get; set; }

        [JsonProperty("'os.features'")]
        public string[] OsFeatures { get; set; }

        [JsonProperty("'os.version'")]
        public string OsVersion { get; set; }
    }
}
