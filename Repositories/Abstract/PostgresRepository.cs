using BasementRPG.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BasementRPG.Repositories.Abstract
{
    public abstract class PostgresRepository
    {
        private PersistentSettings PersistentSettings { get; set; }

        public IDbConnection DbConnection
        {
            get
            {
                var connectionString = $"Host={PersistentSettings.Postgres.ServerName};Username={PersistentSettings.Postgres.UserName};Password={PersistentSettings.Postgres.Password};Database={PersistentSettings.Postgres.DatabaseName}";
                return new NpgsqlConnection(connectionString);
            }
        }

        public PostgresRepository(PersistentSettings persistentSettings)
        {
            PersistentSettings = persistentSettings;
        }
    }
}
