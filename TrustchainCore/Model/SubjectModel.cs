using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrustchainCore.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SubjectModel
    {
        /// <summary>
        /// Subject target id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public byte[] Id { get; set; }

        [JsonProperty(PropertyName = "idtype")]
        public string IdType { get; set; }

        /// <summary>
        /// Not included in the Binary payload for signature verification!
        /// </summary>
        [JsonProperty(PropertyName = "signature", NullValueHandling = NullValueHandling.Ignore)]
        public byte[] Signature { get; set; }

        [JsonProperty(PropertyName = "claim")]
        public JObject Claim { get; set; }

        [JsonProperty(PropertyName = "cost")]
        public int Cost { get; set; }

        [JsonProperty(PropertyName = "activate")]
        public uint Activate { get; set; }

        [JsonProperty(PropertyName = "expire")]
        public uint Expire { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Currently used in TrustGraph
        /// </summary>
        public int Timestamp { get; set; }

        /// <summary>
        /// Not included in the Binary payload for signature verification!
        /// Non serializeable
        /// </summary>
        public byte[] IssuerId { get; set; }

        /// <summary>
        /// FOREIGN KEY to a Trust
        /// Non serializeable
        /// </summary>
        public byte[] TrustId { get; set; }


        public SubjectModel()
        {
            Claim = null;
        }
    }
}
