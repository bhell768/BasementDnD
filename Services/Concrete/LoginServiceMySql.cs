using System.Collections.Generic;
using System.Data;
using BasementDnD.Configuration;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using BasementDnD.Services.Abstract;
using BasementDnD.Models;

namespace BasementDnD.Services.Concrete
{
    public class LoginServiceMySql : MySqlRepository, ILoginService
    {    
        public LoginServiceMySql(PersistentSettings persistentSettings) : base(persistentSettings)
        {

        }
        public async Task<IEnumerable<Login>> Get()
        {
            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var cmd = connection.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT `Id`, `Name`, `Password` FROM `login` ORDER BY `Id` DESC LIMIT 10;";
                return await ReadAllAsync(await cmd.ExecuteReaderAsync());
            }
        }

        public async Task<Login> Get(int id)
        {
            await Connection.OpenAsync();
            var cmd = Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT `Id`, `Name`, `Password` FROM `login` WHERE `Id` = @id";
            BindId(cmd, id);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<int> Create(Login login)
        {
            await Connection.OpenAsync();
            var cmd = Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `login` (`Name`, `Password`) VALUES (@name, @password);";
            BindParams(cmd, login);
            await cmd.ExecuteNonQueryAsync();
            return (int) cmd.LastInsertedId;
        }

        public async Task<bool> Update(int id, Login loginIn)
        {
            await Connection.OpenAsync();
            var cmd = Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE `login` SET `Name` = @name, `Password` = @password WHERE `Id` = @id;";
            BindParams(cmd, loginIn);
            BindId(cmd, id);
            await cmd.ExecuteNonQueryAsync();
            return true;
        }

        public async Task<bool> Remove(Login loginIn)
        {
            await Connection.OpenAsync();
            var txn = await Connection.BeginTransactionAsync();
            try
            {
                var cmd = Connection.CreateCommand();
                cmd.CommandText = @"DELETE FROM `login` where `ID` = @id";
                BindId(cmd, loginIn.Id);
                await cmd.ExecuteNonQueryAsync();
                await txn.CommitAsync();
            }
            catch
            {
                await txn.RollbackAsync();
                throw;
            }
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            await Connection.OpenAsync();
            var txn = await Connection.BeginTransactionAsync();
            try
            {
                var cmd = Connection.CreateCommand();
                cmd.CommandText = @"DELETE FROM `login`";
                BindId(cmd, id);
                await cmd.ExecuteNonQueryAsync();
                await txn.CommitAsync();
            }
            catch
            {
                await txn.RollbackAsync();
                throw;
            }
            return true;
        }

        private void BindId(MySqlCommand cmd, int id)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
        }

        private void BindParams(MySqlCommand cmd, Login login)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = login.Name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = login.Password,
            });
        }
        private async Task<List<Login>> ReadAllAsync(DbDataReader reader)
        {
            var logins = new List<Login>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var login = new Login()
                    {
                        Id = await reader.GetFieldValueAsync<int>(0),
                        Name = await reader.GetFieldValueAsync<string>(1),
                        Password = await reader.GetFieldValueAsync<string>(2)
                    };
                    logins.Add(login);
                }
            }
            return logins;
        }
    }
}