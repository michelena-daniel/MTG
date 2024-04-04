using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGFront_Back.DTOs.MtgApi.Booster
{
    public class BoosterCardRootDto
    {
        [JsonProperty("cards", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cards")]
        public BoosterCardDto BoosterCardDto { get; set; }
    }
}
