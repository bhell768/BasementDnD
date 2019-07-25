using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementRPG.Models.Race
{
    public class Race
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {get; set;}

        [BsonElement("RaceName")]
        public string RaceName { get; set; }

        [BsonElement("ShortDescription")]
        public string ShortDescription { get; set; }

        [BsonElement("PhysicalDescription")]
        public string PhysicalDescription { get; set; }

        [BsonElement("Society")]
        public string Society { get; set; }

        [BsonElement("Relations")]
        public string Relations { get; set; }

        [BsonElement("AlignmentReligion")]
        public string AlignmentReligion { get; set; }

        [BsonElement("Adventurers")]
        public string Adventurers { get; set; }

        [BsonElement("MaleNames")]
        public List<string> MaleNames { get; set; }

        [BsonElement("FemaleNames")]
        public List<string> FemaleNames { get; set; }

        [BsonElement("Traits")]
        public RacialTraits Traits {get; set;}
    }
}