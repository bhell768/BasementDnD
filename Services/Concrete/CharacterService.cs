using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using BasementDnD.Models;
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

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IConfiguration config, IHttpContextAccessor httpContextAccessor, PersistentSettings persistentSettings) : base(persistentSettings)
        {
            var client = new MongoClient(config.GetConnectionString("BasementDnDDB"));
            var database = client.GetDatabase("BasementDnDCharacter");
            _characters = database.GetCollection<Character>("Character");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Character>> Get()
        {
            var username =  _httpContextAccessor.HttpContext.User.Identity.Name;
            if(username == null)
            {
                return null;
            }
            using (var conn = Connection)
            {
                //thinking about seperating this into another service
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"select `CharacterObjId` from users, userCharacters where users.id_bin = userCharacters.userId_bin and users.username = @username";
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@username",
                    DbType = DbType.String,
                    Value = username,
                });
                var objIds = await ReadAllAsync(await cmd.ExecuteReaderAsync());
                
                return _characters.Find(character => objIds.Contains(character.Id)).ToList();
            }
        }
        //TODO finish user access for other character services and setting user access for created by user
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