CREATE TABLE Card(
   [object]          VARCHAR(30) NOT NULL 
  ,id                UNIQUEIDENTIFIER PRIMARY KEY
  ,oracle_id         VARCHAR(30)
  ,multiverse_ids    VARCHAR(30)
  ,mtgo_id           INT  NOT NULL
  ,arena_id          INT  NOT NULL
  ,tcgplayer_id      INT  NOT NULL
  ,cardmarket_id     INT  NOT NULL
  ,[name]              VARCHAR(30)
  ,lang              VARCHAR(30)
  ,released_at       VARCHAR(30)
  ,uri               VARCHAR(30)
  ,scryfall_uri      VARCHAR(30)
  ,layout            VARCHAR(30)
  ,highres_image     BIT NOT NULL
  ,image_status      VARCHAR(30)
  ,mana_cost         VARCHAR(30)
  ,cmc               FLOAT  NOT NULL
  ,type_line         VARCHAR(30)
  ,oracle_text       VARCHAR(30)
  ,[power]             VARCHAR(30)
  ,toughness         VARCHAR(30)
  ,colors            VARCHAR(30)
  ,color_identity    VARCHAR(30)
  ,keywords          VARCHAR(30)
  ,games             VARCHAR(30)
  ,reserved          BIT NOT NULL
  ,foil              BIT NOT NULL
  ,nonfoil           BIT NOT NULL
  ,finishes          VARCHAR(30)
  ,oversized         BIT NOT NULL
  ,promo             BIT NOT NULL
  ,reprint           BIT NOT NULL
  ,variation         BIT NOT NULL
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
  ,digital           BIT NOT NULL
  ,rarity            VARCHAR(30)
  ,card_back_id      VARCHAR(30)
  ,artist            VARCHAR(30)
  ,artist_ids        VARCHAR(30)
  ,illustration_id   VARCHAR(30)
  ,border_color      VARCHAR(30)
  ,frame             VARCHAR(30)
  ,full_art          BIT NOT NULL
  ,textless          BIT NOT NULL
  ,booster           BIT NOT NULL
  ,story_spotlight   BIT NOT NULL
  ,edhrec_rank       INT  NOT NULL
  ,produced_mana     VARCHAR(30)
);