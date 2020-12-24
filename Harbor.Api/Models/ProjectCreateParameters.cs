using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.Models
{
    public class ProjectCreateParameters
    {
        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("public")]
        public bool IsPublic { get; set; }
    }
}
