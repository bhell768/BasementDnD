using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementRPG.Models.CClass
{
    public class Class
    {
        [BsonElement("ClassName")]
        public string ClassName { get; set; }
        
        [BsonElement("ClassSkills")]
        public List<ClassSkill> ClassSkills { get; set; }
    }
}