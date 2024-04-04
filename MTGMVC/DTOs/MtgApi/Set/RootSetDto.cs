using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGFront_Back.DTOs.MtgApi.Set
{
    public class RootSetDto
    {
        [JsonProperty("set", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("set")]
        public SetDto SetDto { get; set; }
    }
}
