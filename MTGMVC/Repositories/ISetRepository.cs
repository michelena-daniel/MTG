﻿using MTGFront_Back.DTOs.Scryfall.Sets;
using MTGFront_Back.Repositories.CommandText;
using Dapper;
using MTGFront_Back.Models;
using System.Linq;
using System.Xml.Linq;
using System;

namespace MTGFront_Back.Repositories
{
    public interface ISetRepository
    {
        Task<int> InsertSet(ScryfallSetDto scryfallSet);
        Task<int> CountSets();
        Task<IList<SetModel>> GetAllSetNames();
    }

    public class SetRepository: BaseRepository, ISetRepository
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
