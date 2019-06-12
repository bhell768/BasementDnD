using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasementDnD.Configuration
{
    public class PersistentSettings
    {
        public PostgresConfiguration Postgres { get; set; }
        public MySqlConfiguration MySql {get; set;}
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
}
