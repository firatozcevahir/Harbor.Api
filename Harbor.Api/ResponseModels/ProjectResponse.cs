using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harbor.Api.ResponseModels
{
    public class ProjectResponse
    {
        [JsonProperty("project_id")]
        public long ProjectId { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("togglable")]
        public bool Togglable { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty("current_user_role_id")]
        public int CurrentUserRoleId { get; set; }

        [JsonProperty("current_user_role_ids")]
        public int[] CurrentUserRoleIds { get; set; }

        [JsonProperty("repo_count")]
        public long RepoCount { get; set; }

        [JsonProperty("chart_count")]
        public ulong ChartCount { get; set; }

        [JsonProperty("metadata")]
        public MetaData MetaData { get; set; }

        [JsonProperty("cve_allowlist")]
        public CVEAllowList CveAllowList { get; set; }

        [JsonProperty("registry_id")]
        public long RegistryId { get; set; }

    }

    public class MetaData
    {
        [JsonProperty("public")]
        public string Public { get; set; }

        [JsonProperty("enable_content_trust")]
        public string EnableContentTrust { get; set; }

        [JsonProperty("auto_scan")]
        public string AutoScan { get; set; }

        [JsonProperty("severity")]
        public string Severity { get; set; }

        [JsonProperty("reuse_sys_cve_allowlist")]
        public string ReUseSysCVEAllowList { get; set; }

        [JsonProperty("prevent_vul")]
        public string PreventVul { get; set; }

        [JsonProperty("retention_id")]
        public string RetentionId { get; set; }
    }

    public class CVEAllowList
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("items")]
        public IList<CVEAllowListItem> Items { get; set; }

        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("expires_at")]
        public int ExpiresAt { get; set; }

    }

    public class CVEAllowListItem
    {
        [JsonProperty("cve_id")]
        public string CVEId { get; set; }
    }
}
