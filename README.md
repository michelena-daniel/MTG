# MTG
 Hobby fun project to consume MTG API https://api.magicthegathering.io/v1/ and Scryfall API https://api.scryfall.com/ in order to process and persist their data. 

 Tech stack trace:

- Pseudo MVC pattern, .NET 8.
- Dapper as micro-ORM for quick and light querying using SQL over linQ for now.
- Redis for distributed caching.
- Docker to run containers.
