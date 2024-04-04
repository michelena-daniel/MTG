namespace MTGMVC.Repositories.CommandText
{
    public interface ICommandText
    {
        public string InsertSet { get; }
        public string CountSets { get; }
        public string GetSetNames { get; }
    }
    public class CommandText : ICommandText
    {
        public string InsertSet => "INSERT INTO [Sets] ([object], [id], [code], [mtgo_code], [arena_code], [tcgplayer_id], [name], [uri], [scryfall_uri], [search_uri], [released_at], [set_type], [card_count], [digital], [nonfoil_only], [foil_only], [icon_svg_uri])" +
            " VALUES(@object, @id, @code, @mtgocode, @arenacode, @tcgplayerid, @name, @uri, @scryfalluri, @searchuri, @releasedat, @settype, @cardcount, @digital, @nonfoilonly, @foilonly, @iconsvguri)";

        public string CountSets => "SELECT COUNT(*) FROM [MTGCards].[dbo].[Sets]";

        public string GetSetNames => "SELECT Name, Code FROM dbo.Sets;";
    }
}
