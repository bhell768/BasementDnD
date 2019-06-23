using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BasementDnD.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using BasementDnD.Services.Abstract;
using BasementDnD.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BasementDnD.Services.Concrete
{
    public class LoginServiceMySql : MySqlRepository, ILoginService
    {    
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginServiceMySql(PersistentSettings persistentSettings, IHttpContextAccessor httpContextAccessor) : base(persistentSettings)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Login(string username, string password)
        {
            Login user;
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT `Id_Bin`, `Name`,`Username`, `Password` FROM `users` WHERE `Username` = @username";
                BindUName(cmd, username);
                var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
                user = result.Count > 0 ? result[0] : null;
            }
            if(user == null || user.Password != password)
            {
                    return "Invalid Login";
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Tester"), //add in roles and full name
                new Claim("FullName", user.Name),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true

                //IsPersitent = user defined value


            };

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity), 
                authProperties);

            return "User Logged In";
        }

        public async Task<string> Logout()
        {
            //not sure what can go wrong here
            //will implement any exception handeling
            //not sure what happens if a logout is attempted on a not logged in user
            await _httpContextAccessor.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return "Logged Out";
        }

        public async Task<string> GetInfo()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }

        public async Task<Login> Get(byte[] id)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"SELECT `Id`, `Name`, `Password` FROM `login` WHERE `Id` = @id";
                BindId(cmd, id);
                var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
                return result.Count > 0 ? result[0] : null;
            }
        }
        public async Task<int> Create(Login login)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO `login` (`Name`, `Password`) VALUES (@name, @password);";
                BindParams(cmd, login);
                await cmd.ExecuteNonQueryAsync();
                return (int) cmd.LastInsertedId;
            }
        }

        public async Task<bool> Update(byte[] id, Login loginIn)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"UPDATE `login` SET `Name` = @name, `Password` = @password WHERE `Id` = @id;";
                BindParams(cmd, loginIn);
                BindId(cmd, id);
                await cmd.ExecuteNonQueryAsync();
                return true;
                //I think the begin transaction and rollback async can be used here
            }
        }

        public async Task<bool> Remove(Login loginIn)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var txn = await conn.BeginTransactionAsync();
                try
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"DELETE FROM `login` where `ID_Bin` = @id";
                    BindId(cmd, loginIn.Id_Bin);
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
        }

        public async Task<bool> Remove(byte[] id)
        {
            using (var conn = Connection)
            {
                await conn.OpenAsync();
                var txn = await conn.BeginTransactionAsync();
                try
                {
                    var cmd = conn.CreateCommand();
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
        }

        private void BindId(MySqlCommand cmd, byte[] id)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Binary,
                Value = id,
            });
        }

        private void BindUName(MySqlCommand cmd, string username)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = username,
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
                        Id_Bin = await reader.GetFieldValueAsync<byte[]>(0),
                        Name = await reader.GetFieldValueAsync<string>(1),
                        Username = await reader.GetFieldValueAsync<string>(2),
                        Password = await reader.GetFieldValueAsync<string>(3)
                    };
                    logins.Add(login);
                }
            }
            return logins;
        }
    }
}