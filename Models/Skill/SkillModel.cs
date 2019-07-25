using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementRPG.Models.Skill
{
    public class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("SkillName")]
        public string SkillName {get;set;}

        [BsonElement("SkillCode")]
        public string SkillCode {get;set;}

        [BsonElement("AbilityModType")]
        public string AbilityModType {get; set;}

        [BsonElement("Untrained")]
        public bool Untrained { get; set; }

        [BsonElement("TrainedOnly")]
        public bool TrainedOnly { get; set; }

        [BsonElement("ShortDescription")]
        public string ShortDescriptions { get; set; }

        [BsonElement("CheckDescription")]
        public string CheckDescriptions { get; set; }

        [BsonElement("ActionDescription")]
        public string ActionDescriptions { get; set; }

        [BsonElement("TryAgainDescription")]
        public string TryAgainDescriptions { get; set; }

        [BsonElement("SpecialDescription")]
        public string SpecialDescriptions { get; set; }

        [BsonElement("UntrainedDescription")]
        public string UntrainedDescription { get; set; }

        [BsonElement("SkillTables")]
        public List<SkillTable> SkillTables { get; set; }
    }
}