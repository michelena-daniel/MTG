using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGMVC.DTOs.MtgApi.Card
{
    public class CardDto
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("manaCost", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("manaCost")]
        public string ManaCost { get; set; }

        [JsonProperty("cmc", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cmc")]
        public double? Cmc { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("types", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("types")]
        public List<string> Types { get; set; }

        [JsonProperty("rarity", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("set", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("set")]
        public string Set { get; set; }

        [JsonProperty("setName", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("setName")]
        public string SetName { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonProperty("layout", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("layout")]
        public string Layout { get; set; }

        [JsonProperty("multiverseid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("multiverseid")]
        public string Multiverseid { get; set; }

        [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("rulings", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rulings")]
        public List<RulingDto> Rulings { get; set; }

        [JsonProperty("printings", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("printings")]
        public List<string> Printings { get; set; }

        [JsonProperty("originalText", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("originalText")]
        public string OriginalText { get; set; }

        [JsonProperty("originalType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("originalType")]
        public string OriginalType { get; set; }

        [JsonProperty("legalities", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("legalities")]
        public List<LegalityDto> Legalities { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
