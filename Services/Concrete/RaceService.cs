using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using BasementRPG.Models.Race;
using BasementRPG.Configuration;
using BasementRPG.Services.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;

namespace BasementRPG.Services.Concrete
{
    public class RaceService: IRaceService 
    {
        private readonly IMongoCollection<Race> _races;

        private readonly IMongoCollection<Race> _coreRaces;
        private PersistentSettings PersistentSettings {get; set;}

        public RaceService(IConfiguration config, PersistentSettings persistentSettings)
        {
            PersistentSettings = persistentSettings;
            var client = new MongoClient(config.GetConnectionString(PersistentSettings.Mongo.Client));
            var database = client.GetDatabase(PersistentSettings.Mongo.CharacterDatabase);
            _races = database.GetCollection<Race>("Race");
            _coreRaces = database.GetCollection<Race>("CoreRace");
        }

        public List<Race> Get() 
        {
            return _races.Find(race => true).ToList();
        }

        public List<Race> GetCore() 
        {
            return _coreRaces.Find(race => true).ToList();
        }

        public Race Get(string id)
        {
            return _races.Find<Race>(race => race.Id == id).FirstOrDefault();
        }
        public Race GetCore(string id)
        {
            return _coreRaces.Find<Race>(race => race.Id == id).FirstOrDefault();
        }

        public Race Create(Race race)
        {
            _races.InsertOne(race);

            return race;
        }

        public Race Update(string id, Race raceIn)
        {
            _races.ReplaceOne(race => race.Id == id, raceIn);

            return raceIn;
        }

        public bool Remove(Race raceIn)
        {
            _races.DeleteOne(race => race.Id == raceIn.Id);

            return true;
        }

        public bool Remove(string id)
        {
            _races.DeleteOne(race => race.Id == id);

            return true;
        }
    }
}