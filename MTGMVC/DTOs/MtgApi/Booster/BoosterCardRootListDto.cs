using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGMVC.DTOs.MtgApi.Booster
{
    public class BoosterCardRootListDto
    {
        [JsonProperty("cards", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("cards")]
        public List<BoosterCardDto> BoosterCardDtos { get; set; }
    }
}
