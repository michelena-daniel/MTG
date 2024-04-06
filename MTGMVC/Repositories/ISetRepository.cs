using Dapper;
using System.Linq;
using System.Xml.Linq;
using System;
using MTGMVC.Repositories.CommandText;
using MTGMVC.DTOs.Scryfall.Sets;
using MTGMVC.Models;
using MTGMVC.DTOs.Scryfall.Cards;
using MTGMVC.DTOs.Custom;

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
                return await conn.ExecuteAsync(_commandText.InsertCard, cleanCard);
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
