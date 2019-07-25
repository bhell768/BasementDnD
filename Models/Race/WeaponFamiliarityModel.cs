using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementRPG.Models.Race
{
    public class WeaponFamiliarity
    {
        [BsonElement("TypesProficient")]
        public List<string> TypesProficient { get; set; }

        [BsonElement("IsNamedProficient")]
        public bool IsNamedProficient { get; set; }
    }
}