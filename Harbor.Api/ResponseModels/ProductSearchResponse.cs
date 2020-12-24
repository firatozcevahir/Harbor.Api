using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Harbor.Api.Models;

namespace Harbor.Api.ResponseModels
{
    public class ProductSearchResponse
    {

        [JsonProperty("project")]
        public IList<ProjectResponse> Projects { get; set; }

        [JsonProperty("repository")]
        public IList<Repository> Repositories { get; set; }

        [JsonProperty("chart")]
        public IList<object> Charts { get; set; }
    }
}
