﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Dtos.Account
{
    [JsonObject("tokenSetting")]
    public class TokenSettings
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }
        [JsonProperty("issuer")]
        public string Issuer { get; set; }
        [JsonProperty("audience")]
        public string Audience { get; set; }
        [JsonProperty("accessExpiration")]
        public int AccessExpiration { get; set; }
        [JsonProperty("refreshExpiration")]
        public int RefreshExpiration { get; set; }
    }
}
