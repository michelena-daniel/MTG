using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGMVC.DTOs.MtgApi.Set
{
    public class SetDto
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("booster", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("booster")]
        public List<object> Booster { get; set; }

        [JsonProperty("releaseDate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("block", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("block")]
        public string Block { get; set; }

        [JsonProperty("onlineOnly", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("onlineOnly")]
        public bool? OnlineOnly { get; set; }
    }
}
