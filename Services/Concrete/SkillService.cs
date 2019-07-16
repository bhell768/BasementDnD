using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using BasementDnD.Models.Skill;
using BasementDnD.Configuration;
using BasementDnD.Services.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;

namespace BasementDnD.Services.Concrete
{
    public class SkillService: ISkillService 
    {
        private readonly IMongoCollection<Skill> _skills;

        private PersistentSettings PersistentSettings {get; set;}

        public SkillService(IConfiguration config, PersistentSettings persistentSettings)
        {
            PersistentSettings = persistentSettings;
            var client = new MongoClient(config.GetConnectionString(PersistentSettings.Mongo.Client));
            var database = client.GetDatabase(PersistentSettings.Mongo.CharacterDatabase);
            _skills = database.GetCollection<Skill>("SkillTemplate");
        }

        public List<Skill> Get()
        {
            return _skills.Find(skill => true).ToList();
        }

        public Skill Get(string id)
        {
            return _skills.Find(skill => skill.Id == id).FirstOrDefault();
        }
    }
}