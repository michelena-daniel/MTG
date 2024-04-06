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

        public string InsertCard => "INSERT INTO [Card] (id, oracle_id, multiverse_ids, mtgo_id, arena_id, tcgplayer_id, cardmarket_id, name, lang, released_at, uri, scryfall_uri, layout, highres_image, image_status, mana_cost, cmc, type_line, oracle_text, power, toughness, colors, color_identity, keywords, games, reserved, foil, nonfoil, finishes, oversized, promo, reprint, variation, set_id, set_name, set_type, set_uri, set_search_uri, scryfall_set_uri, rulings_uri, prints_search_uri, collector_number, digital, rarity, card_back_id, artist, artist_ids, illustration_id, border_color, frame, full_art, textless, booster, story_spotlight, edhrec_rank, produced_mana)" +
        " VALUES(@Id, @OracleId, @MultiverseIds, @MtgoId, @ArenaId, @TcgplayerId, @CardmarketId, @Name, @Lang, @ReleasedAt, @Uri, @ScryfallUri, @Layout, @HighresImage, @ImageStatus, @ManaCost, @Cmc, @TypeLine, @OracleText, @Power, @Toughness, @Colors, @ColorIdentity, @Keywords, @Games, @Reserved, @Foil, @Nonfoil, @Finishes, @Oversized, @Promo, @Reprint, @Variation, @SetId, @SetName, @SetType, @SetUri, @SetSearchUri, @ScryfallSetUri, @RulingsUri, @PrintsSearchUri, @CollectorNumber, @Digital, @Rarity, @CardBackId, @Artist, @ArtistIds, @IllustrationId, @BorderColor, @Frame, @FullArt, @Textless, @Booster, @StorySpotlight, @EdhrecRank, @ProducedMana)";
    }
}
