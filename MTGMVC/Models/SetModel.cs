﻿using System.Text.Json.Serialization;

namespace MTGMVC.Models
{
    public class SetModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
