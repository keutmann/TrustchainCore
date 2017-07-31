using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrustchainCore.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TrustModel : CoreModel
    {
        [JsonProperty(PropertyName = "trustid")]
        public byte[] TrustId { get; set; }

        [JsonProperty(PropertyName = "issuer")]
        public IssuerModel Issuer { get; set; }

        [JsonIgnore]
        public string DatabaseName { get; set; }
    }
}
