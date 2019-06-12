using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementDnD.Models
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
        public string Class {get; set;}

        [BsonElement("Description")]
        public string Description {get; set;}
    }
}