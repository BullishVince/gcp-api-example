using System.Text.Json.Serialization;

namespace FirestoreApiExample.Models
{
    public class FirebaseSettings
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("private_key_id")]
        public string PrivateKeyId { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("private_key")]
        public string PrivateKey { get; set; }
        [JsonPropertyName("client_email")]
        public string ClientEmail { get; set; }
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
        [JsonPropertyName("auth_uri")]
        public string AuthUri { get; set; }
        [JsonPropertyName("token_uri")]
        public string TokenUri { get; set; }
        [JsonPropertyName("auth_provider_x509_cert_url")]
        public string AuthProviderUrl { get; set; }
        [JsonPropertyName("client_x509_cert_url")]
        public string ClientCertUrl { get; set; }

    }
}
