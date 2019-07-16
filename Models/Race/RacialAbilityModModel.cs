using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementDnD.Models.Race
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