using Dapper;
using System.Linq;
using System.Xml.Linq;
using System;
using MTGMVC.Repositories.CommandText;
using MTGMVC.DTOs.Scryfall.Sets;
using MTGMVC.Models;
using MTGMVC.DTOs.Scryfall.Cards;
using MTGMVC.DTOs.Custom;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace MTGMVC.Repositories
{
    public interface ISetRepository
    {
        Task<int> InsertSet(ScryfallSetDto scryfallSet);
        Task<int> CountSets();
        Task<IList<SetModel>> GetAllSetNames();
        Task<int> InsertCardAsync(CleanCardDto cleanCard);
    }

    public class SetRepository : BaseRepository, ISetRepository
    {
        private readonly ICommandText _commandText;

        public SetRepository(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;
        }

        public async Task<int> InsertSet(ScryfallSetDto scryfallSet)
        {
            return await WithConnection(async conn =>
            {
                return await conn.ExecuteAsync(_commandText.InsertSet, new
                {
                    scryfallSet.Object,
                    scryfallSet.Id,
                    scryfallSet.Code,
                    scryfallSet.MtgoCode,
                    scryfallSet.ArenaCode,
                    scryfallSet.TcgplayerId,
                    scryfallSet.Name,
                    scryfallSet.Uri,
                    scryfallSet.ScryfallUri,
                    scryfallSet.SearchUri,
                    scryfallSet.ReleasedAt,
                    scryfallSet.SetType,
                    scryfallSet.CardCount,
                    scryfallSet.Digital,
                    scryfallSet.NonfoilOnly,
                    scryfallSet.FoilOnly,
                    scryfallSet.IconSvgUri
                });
            });
        }


        public async Task<int> InsertCardAsync(CleanCardDto cleanCard)
        {
            return await WithConnection(async conn =>
            {
                return await conn.ExecuteAsync(_commandText.InsertCard, new
                {
                    cleanCard.Object,
                    cleanCard.Id,
                    cleanCard.OracleId,
                    MultiverseIds = JsonConvert.SerializeObject(cleanCard.MultiverseIds),
                    cleanCard.MtgoId,
                    cleanCard.ArenaId,
                    cleanCard.TcgplayerId,
                    cleanCard.CardmarketId,
                    cleanCard.Name,
                    cleanCard.Lang,
                    cleanCard.ReleasedAt,
                    cleanCard.Uri,
                    cleanCard.ScryfallUri,
                    cleanCard.Layout,
                    cleanCard.HighresImage,
                    cleanCard.ImageStatus,
                    cleanCard.ManaCost,
                    cleanCard.Cmc,
                    cleanCard.TypeLine,
                    cleanCard.OracleText,
                    cleanCard.Power,
                    cleanCard.Toughness,
                    Colors = JsonConvert.SerializeObject(cleanCard.Colors),
                    ColorIdentity = JsonConvert.SerializeObject(cleanCard.ColorIdentity),
                    KeyWords = JsonConvert.SerializeObject(cleanCard.Keywords),
                    Games = JsonConvert.SerializeObject(cleanCard.Games),
                    cleanCard.Reserved,
                    cleanCard.Foil,
                    cleanCard.Nonfoil,
                    Finishes = JsonConvert.SerializeObject(cleanCard.Finishes),
                    cleanCard.Oversized,
                    cleanCard.Promo,
                    cleanCard.Reprint,
                    cleanCard.Variation,
                    cleanCard.SetId,
                    cleanCard.SetName,
                    cleanCard.SetType,
                    cleanCard.SetUri,
                    cleanCard.SetSearchUri,
                    cleanCard.ScryfallSetUri,
                    cleanCard.RulingsUri,
                    cleanCard.PrintsSearchUri,
                    cleanCard.CollectorNumber,
                    cleanCard.Digital,
                    cleanCard.Rarity,
                    cleanCard.CardBackId,
                    cleanCard.Artist,
                    ArtistIds = JsonConvert.SerializeObject(cleanCard.ArtistIds),
                    cleanCard.IllustrationId,
                    cleanCard.BorderColor,
                    cleanCard.Frame,
                    cleanCard.FullArt,
                    cleanCard.Textless,
                    cleanCard.Booster,
                    cleanCard.StorySpotlight,
                    cleanCard.EdhrecRank,
                    ProducedMana = JsonConvert.SerializeObject(cleanCard.ProducedMana)
                });
            });
        }

        public async Task<int> CountSets()
        {
            return await WithConnection(async conn =>
            {
                return await conn.QueryFirstOrDefaultAsync<int>(_commandText.CountSets);
            });
        }

        public async Task<IList<SetModel>> GetAllSetNames()
        {
            return await WithConnection(async conn =>
            {
                return (await conn.QueryAsync<SetModel>(_commandText.GetSetNames)).ToList();
            });
        }
    }
}
