using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api.ResponseModels
{
    public class CurrentUserPermissionResponse
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }
    }
}
