using MTGMVC.DTOs.Scryfall.Cards;
using MTGMVC.DTOs.Scryfall.Sets;
using Newtonsoft.Json;

namespace MTGMVC.Clients
{
    public interface IScryfallClient
    {
        Task<ScryfallSetRootDto> GetAllScryfallSetsAsync();
        Task<ScryfallCardsRoot> GetScryfallCardsBySetAsync(string setCode);
        Task<ScryfallCardDto> GetCardByScryfallIdAsync(string scryfallId);
    }

    public class ScryfallClient : IScryfallClient
    {
        private IHttpClientFactory _httpClientFactory;
        private ILogger<ScryfallClient> _logger;

        public ScryfallClient(IHttpClientFactory httpClientFactory, ILogger<ScryfallClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<ScryfallSetRootDto> GetAllScryfallSetsAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Scryfall");

                var content = await client.GetStringAsync("sets");
                var deserializedSets = JsonConvert.DeserializeObject<ScryfallSetRootDto>(content);

                return deserializedSets ?? throw new Exception($"Unable to serialize sets. Returned json string is: {content}.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get set from Scryfall client {ex}", ex);
                throw;
            }
        }

        public async Task<ScryfallCardsRoot> GetScryfallCardsBySetAsync(string setCode)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("Scryfall");

                var content = await client.GetStringAsync($"cards/search?q=e:{setCode}");
                var deserializedCards = JsonConvert.DeserializeObject<ScryfallCardsRoot>(content);

                return deserializedCards ?? throw new Exception($"Unable to serialize cards by set. Returned json string is: {content}.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get set from Scryfall client {ex}", ex);
                throw;
            }
        }

        public async Task<ScryfallCardDto> GetCardByScryfallIdAsync(string scryfallId)
        {
            var client = _httpClientFactory.CreateClient("Scryfall");

            var content = await client.GetStringAsync($"cards/{scryfallId}");
            var deserializedCard = JsonConvert.DeserializeObject<ScryfallCardDto>(content);

            return deserializedCard ?? throw new Exception("Unable to search card by id {scryfallId}");
        }
    }
}
