using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using BasementDnD.Models.Character;
using BasementDnD.Configuration;
using BasementDnD.Services.Abstract;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;

namespace BasementDnD.Services.Concrete
{
    public class CharacterService: MySqlRepository, ICharacterService 
    {
        private readonly IMongoCollection<Character> _characters;

        private readonly ILoginService _loginService;
        private readonly ICharacterOwnership _characterOwnership;
        private PersistentSettings PersistentSettings {get; set;}

        public CharacterService(IConfiguration config, ICharacterOwnership characterOwnership, ILoginService loginService,PersistentSettings persistentSettings) : base(persistentSettings)
        {
            PersistentSettings = persistentSettings;
            var client = new MongoClient(config.GetConnectionString(PersistentSettings.Mongo.Client));
            var database = client.GetDatabase(PersistentSettings.Mongo.CharacterDatabase);
            _characters = database.GetCollection<Character>("Character");
            _loginService = loginService;
            _characterOwnership = characterOwnership;
        }

        public async Task<List<Character>> Get()
        {
            byte[] userID = _loginService.VerifyLogin();
            if(userID == null)
            {
                return null;
            }

            var objIds = await _characterOwnership.GetAllCharacters(userID);
                
            return _characters.Find(character => objIds.Contains(character.Id)).ToList();
            
        }
        //TODO finish user access for other character services and setting user access for created by user
        public Character Get(string id)
        {
            byte[] userID = _loginService.VerifyLogin();
            if(userID == null)
            {
                return null;
            }

            var charID = _characterOwnership.CheckCharacter(userID, id);

            if(charID == null)
            {
                return null;
            }

            return _characters.Find<Character>(character => character.Id == id).FirstOrDefault();
        }

        public Character Create(Character character)
        {
            byte[] userID = _loginService.VerifyLogin();
            if(userID == null)
            {
                return null;
            }
            _characters.InsertOne(character);
            
            var result = _characterOwnership.CreateCharacter(userID, character.Id);

            return character;
        }

        public Character Update(string id, Character characterIn)
        {
            byte[] userID = _loginService.VerifyLogin();
            if(userID == null)
            {
                return null;
            }

            var charID = _characterOwnership.CheckCharacter(userID, id);

            if(charID == null)
            {
                return null;
            }
            _characters.ReplaceOne(character => character.Id == id, characterIn);

            return characterIn;
        }

        public bool Remove(Character characterIn)
        {
            byte[] userID = _loginService.VerifyLogin();
            if(userID == null)
            {
                return false;
            }

            var charID = _characterOwnership.CheckCharacter(userID, characterIn.Id);

            if(charID == null)
            {
                return false;
            }
            _characters.DeleteOne(character => character.Id == characterIn.Id);

            return true;
        }

        public bool Remove(string id)
        {
            byte[] userID = _loginService.VerifyLogin();
            if(userID == null)
            {
                return false;
            }

            var charID = _characterOwnership.CheckCharacter(userID, id);

            if(charID == null)
            {
                return false;
            }
            _characters.DeleteOne(character => character.Id == id);

            return true;
        }

        private async Task<List<string>> ReadAllAsync(DbDataReader reader)
        {
            var ids = new List<string>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var id = await reader.GetFieldValueAsync<string>(0);
                    ids.Add(id);
                }
            }
            return ids;
        }
    }
}