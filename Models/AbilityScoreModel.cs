using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementDnD.Models
{
    public class Ability
    {
        [BsonElement("AbilityName")]
        public string AbilityName {get; set;}

        [BsonElement("AbilityCode")]
        public string AbilityCode {get; set;}

        [BsonElement("AbilityScore")]
        public int AbilityScore {get; set;}

        [BsonElement("TempAbilityScore")]
        public int TempAbilityScore {get; set;}

        [BsonElement("TempAbilityBool")]
        public bool TempAbilityBool {get; set;}
    }
}