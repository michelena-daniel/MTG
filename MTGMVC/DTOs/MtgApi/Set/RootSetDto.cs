using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGMVC.DTOs.MtgApi.Set
{
    public class RootSetDto
    {
        [JsonProperty("set", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("set")]
        public SetDto SetDto { get; set; }
    }
}
