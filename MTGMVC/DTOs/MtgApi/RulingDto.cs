using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGMVC.DTOs.MtgApi
{
    public class RulingDto
    {
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
