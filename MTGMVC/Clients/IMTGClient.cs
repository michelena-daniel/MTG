using MTGMVC.DTOs.MtgApi.Booster;
using MTGMVC.DTOs.MtgApi.Card;
using MTGMVC.DTOs.MtgApi.Set;
using Newtonsoft.Json;

namespace MTGMVC.Clients
{
    public interface IMTGClient
    {
        Task<CardRootDto> GetCardAsync(int id);
        Task<RootSetListDto> GetAllSetsAsync();
        Task<BoosterCardRootListDto> GetBoosterPackAsync(string setId);
        Task<BoosterCardRootListDto> GetCardsBySet(string setCode);
    }

    public class MTGClient : IMTGClient
    {
        private IHttpClientFactory _httpClientFactory;
        private ILogger<MTGClient> _logger;

        public MTGClient(IHttpClientFactory httpClientFactory, ILogger<MTGClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<CardRootDto> GetCardAsync(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MTG");

                var content = await client.GetStringAsync($"cards/{id}");
                var deserializedCard = JsonConvert.DeserializeObject<CardRootDto>(content);
                //var content = await client.GetFromJsonAsync<List<CardDto>>($"cards/1");

                return deserializedCard ?? throw new Exception($"Unable to serialize card. Returned json string is: {content}.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get card from MTG client {ex}", ex);
                throw;
            }
        }

        public async Task<RootSetListDto> GetAllSetsAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MTG");

                var content = await client.GetStringAsync($"sets");
                var deserializedSets = JsonConvert.DeserializeObject<RootSetListDto>(content);

                return deserializedSets != null && deserializedSets.RootSetList.Count > 0 ? deserializedSets : throw new Exception("Unable to serialize");
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get sets from MTG client {ex}", ex);
                throw;
            }
        }

        public async Task<BoosterCardRootListDto> GetBoosterPackAsync(string setId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MTG");

                var content = await client.GetStringAsync($"sets/{setId}/booster");
                var deserializedBooster = JsonConvert.DeserializeObject<BoosterCardRootListDto>(content);

                return deserializedBooster != null && deserializedBooster.BoosterCardDtos.Count > 0 ? deserializedBooster : throw new Exception("Unable to serialize");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to get booster pack from MTG client {ex}", ex);
                throw new ArgumentException($"Unable to get booster pack from MTG client {ex}", ex);
            }
        }

        public async Task<BoosterCardRootListDto> GetCardsBySet(string setCode)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("MTG");

                var content = await client.GetStringAsync($"cards?set={setCode}");
                var deserializedSet = JsonConvert.DeserializeObject<BoosterCardRootListDto>(content);
                //var content = await client.GetFromJsonAsync<List<CardDto>>($"cards/1");

                return deserializedSet != null && deserializedSet.BoosterCardDtos.Count > 0 ? deserializedSet : throw new Exception("Unable to serialize");
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to get card from MTG client {ex}", ex);
                throw;
            }
        }
    }
}
