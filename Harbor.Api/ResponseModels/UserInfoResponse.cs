using System;
using Newtonsoft.Json;

namespace Harbor.Api.ResponseModels
{
    public class UserInfoResponse
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("password_version")]
        public string PasswordVersion { get; set; }

        [JsonProperty("realname")]
        public string RealName { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("role_name")]
        public string RoleName { get; set; }

        [JsonProperty("role_id")]
        public int RoleId { get; set; }

        [JsonProperty("sysadmin_flag")]
        public bool SysAdminFlag { get; set; }

        [JsonProperty("admin_role_in_auth")]
        public bool AdminRoleInAuth { get; set; }

        [JsonProperty("reset_uuid")]
        public string ResetUUID { get; set; }

        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }
    }
}
