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

        public string InsertCard => "INSERT INTO [Card] (object,id,oracle_id,multiverse_ids,mtgo_id,arena_id,tcgplayer_id,cardmarket_id,name,lang,released_at,uri,scryfall_uri,layout,highres_image,image_status,mana_cost,cmc,type_line,oracle_text,power,toughness,colors,color_identity,keywords,games,reserved,foil,nonfoil,finishes,oversized,promo,reprint,variation,set_id,set,set_name,set_type,set_uri,set_search_uri,scryfall_set_uri,rulings_uri,prints_search_uri,collector_number,digital,rarity,card_back_id,artist,artist_ids,illustration_id,border_color,frame,full_art,textless,booster,story_spotlight,edhrec_rank,produced_mana)" +
            "VALUES(@object,@id,@oracleid,@multiverseids,@mtgoid,@arenaid,@tcgplayerId,@cardmarketid,@name,@lang,@releasedat,@uri,@scryfalluri,@layout,@highresimage,@imagestatus,@manacost,@cmc,@typeline,@oracletext,@power,@toughness,@colors,@coloridentity,@keywords,@games,@reserved,@foil,@nonfoil,@finishes,@oversized,@promo,@reprint,@variation,@setid,@set,@setname,@settype,@seturi,@setsearchuri,@scryfallseturi,@rulingsuri,@printssearchuri,@collectornumber,@digital,@rarity,@cardbackid,@artist,@artistids,@illustrationid,@bordercolor,@frame,@fullart,@textless,@booster,@storyspotlight,@edhrec_rank,@producedmana);";
    }
}
