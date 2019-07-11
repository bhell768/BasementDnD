using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementDnD.Models
{
    public class Skill
    {
        [BsonElement("SkillName")]
        public string SkillName {get;set;}

        [BsonElement("SkillCode")]
        public string SkillCode {get;set;}

        [BsonElement("AbilityModType")]
        public string AbilityModType {get; set;}

        [BsonElement("SkillRanks")]
        public int SkillRanks { get; set; }

        [BsonElement("MiscMod")]

        public int MiscMod { get; set; }

        [BsonElement("UnTrained")]
        public bool UnTrained { get; set; }
    }
}