using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementRPG.Models.CClass
{
    public class ClassSkill
    {
        [BsonElement("SkillName")]
        public string SkillName {get; set;}
        
        [BsonElement("SkillCode")]
        public string SkillCode {get;set;}

        [BsonElement("IsClassSkill")]
        public bool IsClassSkill {get;set;}
    }
}