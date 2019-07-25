using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementRPG.Models.Race
{
    public class RacialAbilityMod
    {
        [BsonElement("Mod")]
        public int Mod { get; set; }

        [BsonElement("AbilityCode")]
        public string AbilityCode { get; set; }

        [BsonElement("IsPickable")]
        public bool IsPickable { get; set; }
    }
}