using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.CodeAnalysis;
using Pipelines.Sockets.Unofficial.Arenas;
using StackExchange.Redis;
using System.Xml.Linq;

namespace MTGMVC.Repositories.CommandText
{
    public interface ICommandText
    {
        public string InsertSet { get; }
        public string CountSets { get; }
        public string GetSetNames { get; }
        public string InsertCard { get; }
    }
    public class CommandText : ICommandText
    {
        public string InsertSet => "INSERT INTO [Sets] ([object], [id], [code], [mtgo_code], [arena_code], [tcgplayer_id], [name], [uri], [scryfall_uri], [search_uri], [released_at], [set_type], [card_count], [digital], [nonfoil_only], [foil_only], [icon_svg_uri])" +
            " VALUES(@object, @id, @code, @mtgocode, @arenacode, @tcgplayerid, @name, @uri, @scryfalluri, @searchuri, @releasedat, @settype, @cardcount, @digital, @nonfoilonly, @foilonly, @iconsvguri)";

        public string CountSets => "SELECT COUNT(*) FROM [MTGCards].[dbo].[Sets]";

        public string GetSetNames => "SELECT Name, Code FROM dbo.Sets;";

        public string InsertCard => "INSERT INTO [Card] (id, oracleId, multiverseIds, mtgoId, arenaId, tcgplayerId, cardmarketId, name, lang, releasedAt, uri, scryfallUri, layout, highresImage, imageStatus, manaCost, cmc, typeLine, oracleText, power, toughness, colors, colorIdentity, keywords, games, reserved, foil, nonfoil, finishes, oversized, promo, reprint, variation, setId, setName, setType, setUri, setSearchUri, scryfallSetUri, rulingsUri, printsSearchUri, collectorNumber, digital, rarity, cardBackId, artist, artistIds, illustrationId, borderColor, frame, fullArt, textless, booster, storySpotlight, edhrecRank, producedMana)" +
                " VALUES(@Id, @OracleId, @MultiverseIds, @MtgoId, @ArenaId, @TcgplayerId, @CardmarketId, @Name, @Lang, @ReleasedAt, @Uri, @ScryfallUri, @Layout, @HighresImage, @ImageStatus, @ManaCost, @Cmc, @TypeLine, @OracleText, @Power, @Toughness, @Colors, @ColorIdentity, @Keywords, @Games, @Reserved, @Foil, @Nonfoil, @Finishes, @Oversized, @Promo, @Reprint, @Variation, @SetId, @SetName, @SetType, @SetUri, @SetSearchUri, @ScryfallSetUri, @RulingsUri, @PrintsSearchUri, @CollectorNumber, @Digital, @Rarity, @CardBackId, @Artist, @ArtistIds, @IllustrationId, @BorderColor, @Frame, @FullArt, @Textless, @Booster, @StorySpotlight, @EdhrecRank, @ProducedMana)";
    }
}
