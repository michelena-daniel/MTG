using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGFront_Back.DTOs.MtgApi.Booster
{
    public class BoosterCardRootListDto
    {
        [JsonProperty("cards", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cards")]
        public List<BoosterCardDto> BoosterCardDtos { get; set; }
    }
}
