using Microsoft.Extensions.Caching.Distributed;
using MTGMVC.Clients;
using MTGMVC.DTOs.Scryfall.Cards;
using MTGMVC.Extensions;
using MTGMVC.Models;
using MTGMVC.Repositories;

namespace MTGMVC.Services
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
        private IDistributedCache _cache;

        public MagicDataWriterService(ISetRepository setRepository, IScryfallClient scryfallClient, ILogger<MagicDataWriterService> logger, IDistributedCache cache)
        {
            _setRepository = setRepository;
            _scryfallClient = scryfallClient;
            _logger = logger;
            _cache = cache;
        }

        public async Task<IList<SetModel>> GetAllSetNamesAsync()
        {
            try
            {
                var cachedRecords = await _cache.GetRecordAsync<IList<SetModel>>("sets");

                if (cachedRecords == null || !cachedRecords.Any())
                {
                    var persistedSets = await _setRepository.CountSets();
                    if (persistedSets == 0)
                    {
                        var scryfallSets = await _scryfallClient.GetAllScryfallSetsAsync();
                        foreach (var set in scryfallSets.ScryfallSets)
                        {
                            await _setRepository.InsertSet(set);
                        }
                    }

                    var setNames = await _setRepository.GetAllSetNames();
                    await _cache.SetRecordAsync("sets", setNames, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(60));
                    return setNames;
                }

                return cachedRecords;
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
