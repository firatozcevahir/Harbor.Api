using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Harbor.Api.ResponseModels
{
    public class UserSearchResponse
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }
    }
}
