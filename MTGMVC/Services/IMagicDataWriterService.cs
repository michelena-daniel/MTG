using MTGFront_Back.Clients;
using MTGFront_Back.DTOs.Scryfall.Cards;
using MTGFront_Back.Models;
using MTGFront_Back.Repositories;

namespace MTGFront_Back.Services
{
    public interface IMagicDataWriterService
    {
        Task<IList<SetModel>> GetAllSetNamesAsync();
        Task<ScryfallCardDto> GetRandomCardBySet(string setCode);
    }

    public class MagicDataWriterService : IMagicDataWriterService
    {
        private ISetRepository _setRepository;
        private IScryfallClient _scryfallClient;
        private ILogger<MagicDataWriterService> _logger;

        public MagicDataWriterService(ISetRepository setRepository, IScryfallClient scryfallClient, ILogger<MagicDataWriterService> logger)
        {
            _setRepository = setRepository;
            _scryfallClient = scryfallClient;
            _logger = logger;
        }

        public async Task<IList<SetModel>> GetAllSetNamesAsync()
        {
            try
            {
                var persistedSets = await _setRepository.CountSets();
                if (persistedSets == 0)
                {
                    var scryfallSets = await _scryfallClient.GetAllScryfallSetsAsync();
                    foreach(var set in scryfallSets.ScryfallSets)
                    {
                        await _setRepository.InsertSet(set);
                    }
                }

                return await _setRepository.GetAllSetNames();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get sets {ex}", ex);
                throw;
            }            
        }

        public async Task<ScryfallCardDto> GetRandomCardBySet(string setCode)
        {
            try
            {
                var setCards = await _scryfallClient.GetScryfallCardsBySetAsync(setCode);
                Random random = new();
                return setCards.ScryfallCards[random.Next(setCards.ScryfallCards.Count)];
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get cards by set {ex}", ex);
                throw;
            }
        }

        //public async Task<List<ScryfallCardDto>> GetPlayBoosterBySet()
        //{
        //    //1-6: commons from set
        //    // 7: "The List" or 7th common
        //    // 8-10: uncommons
        //    //11: rare/mythic rare
        //    //12: basic land
        //    //13: non-foil wildcard
        //    //14: foil wildcard
        //    //15: ad/token/helper/art/card
        //}
    }
}
