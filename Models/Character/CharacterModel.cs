using System.Collections.Generic;
using MongoDB.Bson;
using BasementDnD.Models.CClass;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementDnD.Models.Character
{
    public class Character
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}

        [BsonElement("Name")]
        public string Name {get; set;}

        [BsonElement("Race")]
        public string Race {get; set;}

        [BsonElement("Class")]
        public Class Class {get; set;}

        [BsonElement("HitPoints")]
        public int HitPoints{get; set;}

        [BsonElement("Speed")]
        public int Speed{get; set;}

        [BsonElement("ArmorClass")]
        public int ArmorClass{get; set;}

        [BsonElement("AbilityScores")]
        public List<Ability> AbilityScores{get; set;}

        //TODO skill ranks go here

        [BsonElement("Description")]
        public string Description {get; set;}
    }
}