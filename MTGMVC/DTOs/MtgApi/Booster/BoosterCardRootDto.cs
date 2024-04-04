using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGMVC.DTOs.MtgApi.Booster
{
    public class BoosterCardRootDto
    {
        [JsonProperty("cards", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cards")]
        public BoosterCardDto BoosterCardDto { get; set; }
    }
}
