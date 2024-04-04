using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGMVC.DTOs.MtgApi
{
    public class LegalityDto
    {
        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonProperty("legality", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("legality")]
        public string Legality { get; set; }
    }
}
