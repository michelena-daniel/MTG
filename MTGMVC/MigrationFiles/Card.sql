CREATE TABLE Card(
   [object]            VARCHAR(30) NOT NULL 
  ,id                VARCHAR(30) PRIMARY KEY
  ,oracle_id         VARCHAR(30)
  ,multiverse_ids    VARCHAR(30)
  ,mtgo_id           BIT  NOT NULL
  ,arena_id          BIT  NOT NULL
  ,tcgplayer_id      BIT  NOT NULL
  ,cardmarket_id     BIT  NOT NULL
  ,[name]              VARCHAR(30)
  ,lang              VARCHAR(30)
  ,released_at       VARCHAR(30)
  ,uri               VARCHAR(30)
  ,scryfall_uri      VARCHAR(30)
  ,layout            VARCHAR(30)
  ,highres_image     VARCHAR(5) NOT NULL
  ,image_status      VARCHAR(30)
  ,mana_cost         VARCHAR(30)
  ,cmc               BIT  NOT NULL
  ,type_line         VARCHAR(30)
  ,oracle_text       VARCHAR(30)
  ,[power]             VARCHAR(30)
  ,toughness         VARCHAR(30)
  ,colors            VARCHAR(30)
  ,color_identity    VARCHAR(30)
  ,keywords          VARCHAR(30)
  ,games             VARCHAR(30)
  ,reserved          VARCHAR(5) NOT NULL
  ,foil              VARCHAR(5) NOT NULL
  ,nonfoil           VARCHAR(5) NOT NULL
  ,finishes          VARCHAR(30)
  ,oversized         VARCHAR(5) NOT NULL
  ,promo             VARCHAR(5) NOT NULL
  ,reprint           VARCHAR(5) NOT NULL
  ,variation         VARCHAR(5) NOT NULL
  ,set_id            VARCHAR(30)
  ,[set]               VARCHAR(30)
  ,set_name          VARCHAR(30)
  ,set_type          VARCHAR(30)
  ,set_uri           VARCHAR(30)
  ,set_search_uri    VARCHAR(30)
  ,scryfall_set_uri  VARCHAR(30)
  ,rulings_uri       VARCHAR(30)
  ,prints_search_uri VARCHAR(30)
  ,collector_number  VARCHAR(30)
  ,digital           VARCHAR(5) NOT NULL
  ,rarity            VARCHAR(30)
  ,card_back_id      VARCHAR(30)
  ,artist            VARCHAR(30)
  ,artist_ids        VARCHAR(30)
  ,illustration_id   VARCHAR(30)
  ,border_color      VARCHAR(30)
  ,frame             VARCHAR(30)
  ,full_art          VARCHAR(5) NOT NULL
  ,textless          VARCHAR(5) NOT NULL
  ,booster           VARCHAR(5) NOT NULL
  ,story_spotlight   VARCHAR(5) NOT NULL
  ,edhrec_rank       BIT  NOT NULL
  ,produced_mana     VARCHAR(30)
);

INSERT INTO Card(object,id,oracle_id,multiverse_ids,mtgo_id,arena_id,tcgplayer_id,cardmarket_id,name,lang,released_at,uri,scryfall_uri,layout,highres_image,image_status,mana_cost,cmc,type_line,oracle_text,power,toughness,colors,color_identity,keywords,games,reserved,foil,nonfoil,finishes,oversized,promo,reprint,variation,set_id,set,set_name,set_type,set_uri,set_search_uri,scryfall_set_uri,rulings_uri,prints_search_uri,collector_number,digital,rarity,card_back_id,artist,artist_ids,illustration_id,border_color,frame,full_art,textless,booster,story_spotlight,edhrec_rank,produced_mana) VALUES (NULL,NULL,NULL,NULL,0,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,'false',NULL,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'false','false','false',NULL,'false','false','false','false',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'false',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'false','false','false','false',0,NULL);