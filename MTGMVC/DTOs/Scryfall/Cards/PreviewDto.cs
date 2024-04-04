using Newtonsoft.Json;

namespace MTGFront_Back.DTOs.Scryfall.Cards
{
    public class PreviewDto
    {
        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("source_uri")]
        public string SourceUri { get; set; }

        [JsonProperty("previewed_at")]
        public string PreviewedAt { get; set; }
    }
}
