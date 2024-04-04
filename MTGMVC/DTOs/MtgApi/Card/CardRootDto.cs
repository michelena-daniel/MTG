using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGFront_Back.DTOs.MtgApi.Card
{
    public class CardRootDto
    {
        [JsonProperty("card", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("card")]
        public CardDto Card { get; set; }
    }
}
