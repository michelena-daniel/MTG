using Newtonsoft.Json;

namespace MTGMVC.DTOs.Scryfall.Sets
{
    public class ScryfallSetRootDto
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public List<ScryfallSetDto> ScryfallSets { get; set; }
    }
}
