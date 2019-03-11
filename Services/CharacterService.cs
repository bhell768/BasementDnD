using System.Collections.Generic;
using System.Linq;
using BasementDnD.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BasementDnD.Services
{
    public class CharacterService
    {
        private readonly IMongoCollection<Character> _characters;

        public CharacterService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BasementDnDDB"));
            var database = client.GetDatabase("BasementDnDDb");
            _characters = database.GetCollection<Character>("Character");
        }

        public List<Character> Get()
        {
            return _characters.Find(character => true).ToList();
        }

        public Character Get(string id)
        {
            return _characters.Find<Character>(character => character.Id == id).FirstOrDefault();
        }

        public Character Create(Character character)
        {
            _characters.InsertOne(character);

            return character;
        }

        public void Update(string id, Character characterIn)
        {
            _characters.ReplaceOne(character => character.Id == id, characterIn);
        }

        public void Remove(Character characterIn)
        {
            _characters.DeleteOne(character => character.Id == characterIn.Id);
        }

        public void Remove(string id)
        {
            _characters.DeleteOne(character => character.Id == id);
        }
    }
}