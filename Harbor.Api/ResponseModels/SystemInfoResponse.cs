using Newtonsoft.Json;

namespace Harbor.Api.ResponseModels
{
    public class SystemInfoResponse
    {
        [JsonProperty("with_notary")]
        public bool WithNotary { get; set; }

        [JsonProperty("auth_mode")]
        public string AuthMode { get; set; }

        [JsonProperty("registry_url")]
        public string RegistryUrl { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("project_creation_restriction")]
        public string ProjectCreationRestriction { get; set; }

        [JsonProperty("self_registration")]
        public bool SelfRegistration { get; set; }

        [JsonProperty("has_ca_root")]
        public bool HasCaRoot { get; set; }

        [JsonProperty("harbor_version")]
        public string HarborVersion { get; set; }

        [JsonProperty("registry_storage_provider_name")]
        public string RegistryStorageProviderName { get; set; }

        [JsonProperty("read_only")]
        public bool ReadOnly { get; set; }

        [JsonProperty("with_chartmuseum")]
        public bool WithChartMuseum { get; set; }

        [JsonProperty("notification_enable")]
        public bool NotificationEnable { get; set; }
    }
}
