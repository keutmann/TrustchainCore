﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrustchainCore.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TrustModel
    {
        [JsonProperty(PropertyName = "trustid")]
        public byte[] TrustId { get; set; }

        [JsonProperty(PropertyName = "head", NullValueHandling = NullValueHandling.Ignore)]
        public HeadModel Head { get; set; }

        [JsonProperty(PropertyName = "issuer")]
        public IssuerModel Issuer { get; set; }

        [JsonProperty(PropertyName = "server", NullValueHandling = NullValueHandling.Ignore)]
        public ServerModel Server { get; set; }

        [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public TimestampCollection Timestamp { get; set; }

        [JsonIgnore]
        public string DatabaseName { get; set; }

        //public TrustModel()
        //{
        //    //Timestamp = new TimestampCollection();
        //}
    }
}
