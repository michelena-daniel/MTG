using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGFront_Back.DTOs.Custom
{
    public class SimplifiedCard
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("manaCost", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("manaCost")]
        public string ManaCost { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("rarity", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("setName", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("setName")]
        public string SetName { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonProperty("imgUrl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("imgUrl")]
        public string ImgUrl { get; set; }
    }
}
