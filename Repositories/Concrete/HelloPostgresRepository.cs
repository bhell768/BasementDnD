using Dapper;
using BasementDnD.Configuration;
using BasementDnD.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace BasementDnD.Repositories.Concrete
{
    public class HelloPostgresRepository : PostgresRepository, IHelloRepository
    {
        public HelloPostgresRepository(PersistentSettings persistentSettings) : base(persistentSettings)
        {
        }

        public string GetHelloMessage(string name)
        {
            using (var connection = DbConnection)
            {
                connection.Open();
                var value = connection.Query<string>("select data from public.\"Demo\" fetch first 1 rows only");
                return value.FirstOrDefault();
            }
        }

        public void UpdateGreetingMessage(string greeting)
        {
            throw new NotImplementedException();
        }
    }
}
