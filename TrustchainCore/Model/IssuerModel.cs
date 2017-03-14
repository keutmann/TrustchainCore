﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrustchainCore.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class IssuerModel
    {
        [JsonProperty(PropertyName = "id")]
        public byte[] Id { get; set; }

        /// <summary>
        /// Not included in the Binary payload for signature verification!
        /// </summary>
        [JsonProperty(PropertyName = "signature")]
        public byte[] Signature { get; set; }


        [JsonProperty(PropertyName = "subject")]
        public SubjectModel[] Subjects { get; set; }

        /// <summary>
        /// Time when the trust was made by the client, included into the hash of the trust and signature.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; } 

    }
}
