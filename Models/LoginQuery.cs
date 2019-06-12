// using System.Collections.Generic;
// using System.Data;
// using System.Data.Common;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;
// using BasementDnD.Services;
// using BasementDnD.Models;

// namespace BasementDnD.Models
// {
//     public class LoginQuery
//     {
//         public readonly LoginSqlDB Db;
//         public LoginQuery(LoginSqlDB db)
//         {
//             Db = db;
//         }

//         public async Task<Login> FindOneAsync(int id)
//         {
//             var cmd = Db.Connection.CreateCommand() as MySqlCommand;
//             cmd.CommandText = @"SELECT `Id`, `Name`, `Password` FROM `test` WHERE `Id` = @id";
//             cmd.Parameters.Add(new MySqlParameter
//             {
//                 ParameterName = "@id",
//                 DbType = DbType.Int32,
//                 Value = id,
//             });
//             var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
//             return result.Count > 0 ? result[0] : null;
//         }

//         public async Task<List<Login>> LatestUsersAsync()
//         {
//             var cmd = Db.Connection.CreateCommand();
//             cmd.CommandText = @"SELECT `Id`, `Name`, `Password` FROM `test` ORDER BY `Id` DESC LIMIT 10;";
//             return await ReadAllAsync(await cmd.ExecuteReaderAsync());
//         }

//         public async Task DeleteAllAsync()
//         {
//             var txn = await Db.Connection.BeginTransactionAsync();
//             try
//             {
//                 var cmd = Db.Connection.CreateCommand();
//                 cmd.CommandText = @"DELETE FROM `test`";
//                 await cmd.ExecuteNonQueryAsync();
//                 await txn.CommitAsync();
//             }
//             catch
//             {
//                 await txn.RollbackAsync();
//                 throw;
//             }
//         }

//         private async Task<List<Login>> ReadAllAsync(DbDataReader reader)
//         {
//             var users = new List<Login>();
//             using (reader)
//             {
//                 while (await reader.ReadAsync())
//                 {
//                     var user = new Login(Db)
//                     {
//                         Id = await reader.GetFieldValueAsync<int>(0),
//                         Name = await reader.GetFieldValueAsync<string>(1),
//                         Password = await reader.GetFieldValueAsync<string>(2)
//                     };
//                     users.Add(user);
//                 }
//             }
//             return users;
//         }
//     }
// }