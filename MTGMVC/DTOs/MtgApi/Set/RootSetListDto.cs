using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MTGFront_Back.DTOs.MtgApi.Set
{
    public class RootSetListDto
    {
        [JsonProperty("sets", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sets")]
        public List<SetDto> RootSetList { get; set; }
    }
}
