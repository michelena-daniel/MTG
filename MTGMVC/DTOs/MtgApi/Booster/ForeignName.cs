using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGFront_Back.DTOs.MtgApi.Booster
{
    public class ForeignName
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("flavor", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("flavor")]
        public string Flavor { get; set; }

        [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonProperty("multiverseid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("multiverseid")]
        public int Multiverseid { get; set; }
    }
}
