using System.Collections.Generic;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BasementDnD.Configuration;

namespace BasementDnD.Services.Abstract
{
    public abstract class MySqlRepository : IDisposable
    {

        private PersistentSettings PersistentSettings { get; set; }

        public MySqlConnection Connection
        {
            get 
            {
             return new MySqlConnection($"server={PersistentSettings.MySql.ServerName};port={PersistentSettings.MySql.Port};database={PersistentSettings.MySql.DatabaseName};uid={PersistentSettings.MySql.UserName};pwd={PersistentSettings.MySql.Password};");
            }
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public MySqlRepository(PersistentSettings persistentSettings)
        {
            PersistentSettings = persistentSettings;
        }
    }
}