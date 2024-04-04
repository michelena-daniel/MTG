using MTGFront_Back.Clients;
using MTGFront_Back.DTOs.Custom;
using MTGFront_Back.DTOs.MtgApi.Booster;

namespace MTGFront_Back.Services
{
    public interface IMTGService
    {
        Task<string> GetCardNameById(int id);
        Task<List<SetsWithIdDto>> GetAllSets();
        Task<List<SimplifiedCard>> GetBoosterPack(string setId);
        Task<BoosterCardDto> GetRandomCardFromSet(string setCode);
    }

    public class MTGService : IMTGService
    {
        private readonly IMTGClient _client;

        public MTGService(IMTGClient client)
        {
            _client = client;
        }

        public async Task<string> GetCardNameById(int id)
        {
            var card = await _client.GetCardAsync(id);
            return card.Card.Name;
        }

        public async Task<List<SetsWithIdDto>> GetAllSets()
        {
            var sets = await _client.GetAllSetsAsync();
            var setNames = new List<SetsWithIdDto>();

            foreach (var set in sets.RootSetList)
            {
                setNames.Add(MapSetsWithId(set.Name, set.Code));
            }
            return setNames;
        }

        public async Task<List<SimplifiedCard>> GetBoosterPack(string setId)
        {
            try
            {
                var boosterPack = await _client.GetBoosterPackAsync(setId.ToString().ToUpper());
                var boosterPackSimplified = new List<SimplifiedCard>();

                foreach (var card in boosterPack.BoosterCardDtos)
                {
                    boosterPackSimplified.Add(MapToSimplifiedCard(card));
                }
                return boosterPackSimplified;
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Unable to get booster pack from MTG client {ex}", ex);
            }            
        }

        public async Task<BoosterCardDto> GetRandomCardFromSet(string setCode)
        {
            //limited to 100 items by MTG API
            var setCards = await _client.GetCardsBySet(setCode);
            Random random = new();
            return setCards.BoosterCardDtos[random.Next(setCards.BoosterCardDtos.Count)];
        }

        private static SimplifiedCard MapToSimplifiedCard(BoosterCardDto card)
        {
            return new SimplifiedCard { Name = card.Name, ManaCost = card.ManaCost, Rarity = card.Rarity, SetName = card.SetName, Text = card.Text, Type = card.Type, ImgUrl = card.ImageUrl };
        }

        private static SetsWithIdDto MapSetsWithId(string name, string code)
        {
            return new SetsWithIdDto { Name = name, SetId = code };
        }
    }
}
