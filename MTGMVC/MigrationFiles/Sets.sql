CREATE TABLE [MTGSets] (
  [object] TEXT,
  [id] TEXT,
  [code] TEXT,
  [mtgo_code] TEXT,
  [arena_code] TEXT,
  [tcgplayer_id] INT,
  [name] TEXT,
  [uri] TEXT,
  [scryfall_uri] TEXT,
  [search_uri] TEXT,
  [released_at] TEXT,
  [set_type] TEXT,
  [card_count] INT,
  [digital] INT,
  [nonfoil_only] INT,
  [foil_only] INT,
  [icon_svg_uri] TEXT
);

INSERT INTO [MTGSets] ([object],[id],[code],[mtgo_code],[arena_code],[tcgplayer_id],[name],[uri],[scryfall_uri],[search_uri],[released_at],[set_type],[card_count],[digital],[nonfoil_only],[foil_only],[icon_svg_uri])
VALUES
('set','2b17794b-15c3-4796-ad6f-0887a0eceeca','mkm','mkm','mkm',23361,'Murders at Karlov Manor','https://api.scryfall.com/sets/2b17794b-15c3-4796-ad6f-0887a0eceeca','https://scryfall.com/sets/mkm','https://api.scryfall.com/cards/search?include_extras=true&include_variations=true&order=set&q=e%3Amkm&unique=prints','2024-02-09','expansion',450,FALSE,FALSE,FALSE,'https://svgs.scryfall.io/sets/mkm.svg?1711339200');
