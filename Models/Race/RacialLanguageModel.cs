using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementDnD.Models.Race
{
    public class RacialLanguage
    {
        [BsonElement("LanguageName")]
        public string LanguageName { get; set; }

        [BsonElement("IsStarter")]
        public bool IsStarter { get; set; }
    }
}