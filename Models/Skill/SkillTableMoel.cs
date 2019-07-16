using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementDnD.Models.Skill
{
    public class SkillTable
    {
        [BsonElement("TableTitle")]
        public string TableTitle { get; set; }

        [BsonElement("Headers")]
        public List<string> Headers { get; set; }

        [BsonElement("DataRows")]
        public List<List<string>> DataRows { get; set; }

        [BsonElement("FootNotes")]
        public List<string> FootNotes { get; set; }

        [BsonElement("Position")]
        public string Position { get; set; }
    }
}