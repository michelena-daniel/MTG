﻿using Newtonsoft.Json;

namespace MTGFront_Back.DTOs.Scryfall.Cards
{
    public class PurchaseUrisDto
    {
        [JsonProperty("tcgplayer")]
        public string Tcgplayer { get; set; }

        [JsonProperty("cardmarket")]
        public string Cardmarket { get; set; }

        [JsonProperty("cardhoarder")]
        public string Cardhoarder { get; set; }
    }
}
