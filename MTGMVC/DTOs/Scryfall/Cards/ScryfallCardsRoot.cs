using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MTGFront_Back.DTOs.Scryfall.Cards
{
    public class ScryfallCardsRoot
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("total_cards")]
        public int TotalCards { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("next_page")]
        public string NextPage { get; set; }

        [JsonProperty("data")]
        public List<ScryfallCardDto> ScryfallCards { get; set; }
    }
}
