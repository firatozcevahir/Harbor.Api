using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.ResponseModels
{
    public class LogResponse
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("op_time")]
        public DateTime OperationTime { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }
    }
}
