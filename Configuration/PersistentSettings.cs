using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasementRPG.Configuration
{
    public class PersistentSettings
    {
        public PostgresConfiguration Postgres { get; set; }
        public MySqlConfiguration MySql {get; set;}
        public MongoConfiguration Mongo {get; set;}
    }

    public class PostgresConfiguration
    {
        public string ServerName { get; set; }

        public string DatabaseName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class MySqlConfiguration
    {
        public string ServerName {get; set;}
        public string DatabaseName {get; set;}
        public string UserName {get; set;}
        public string Password {get; set;}
        public string Port {get; set;}
    }

    public class MongoConfiguration
    {
        public string Client {get; set;}
        public string CharacterDatabase {get; set;}
    }
}
