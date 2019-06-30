using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasementDnD.Models;
using BasementDnD.Configuration;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BasementDnD.Services.Abstract;

namespace BasementDnD.Services.Concrete
{
    public class CharacterOwnership : MySqlRepository, ICharacterOwnership
    {
        public CharacterOwnership(PersistentSettings persistentSettings) : base(persistentSettings)
        {

        }
        public async Task<List<string>> GetAllCharacters(byte[] userID)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"select `CharacterObjId` from userCharacters where userId_bin = @userID";
                BindUID(cmd, userID);
                return await ReadAllAsync(await cmd.ExecuteReaderAsync());
            }
        }

        public async Task<string> CheckCharacter(byte[] userID, string characterID)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"select `CharacterObjId` from userCharacters where userID_bin = @userID and characterObjId = @characterID";
                BindUID(cmd, userID);
                BindCID(cmd, characterID);
                var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
                return result.Count > 0 ? result[0] : null;
            }
        }

        public async Task<bool> CreateCharacter(byte[] userID, string characterID)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"insert into `userCharacters` (userId_bin, characterObjId) 
                    values(@userID, @characterID)";
                BindUID(cmd, userID);
                BindCID(cmd, characterID);
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
        }

        public async Task<bool> DeleteCharacter(byte[] userID, string characterID)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"delete from `userCharacters` where userId_bin = @userID and characterObjId = @ characterID";
                BindUID(cmd, userID);
                BindCID(cmd, characterID);
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
        }

        private void BindUID(MySqlCommand cmd, byte[] userID)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@userID",
                DbType = DbType.Binary,
                Value = userID,
            });
        }

        private void BindCID(MySqlCommand cmd, string characterID)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@characterID",
                DbType = DbType.String,
                Value = characterID,
            });
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