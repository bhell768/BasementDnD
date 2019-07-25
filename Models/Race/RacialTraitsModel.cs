using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasementRPG.Models.Race
{
    public class RacialTraits
    {
        [BsonElement("RacialAbilityMods")]
        public List<RacialAbilityMod> RacialAbilityMods { get; set; }
        
        [BsonElement("Size")]
        public string Size { get; set; }

        [BsonElement("SpeedBase")]
        public int SpeedBase { get; set; }

        //TODO Very Specific Modifiers

        [BsonElement("WeaponFam")]
        public WeaponFamiliarity WeaponFam { get; set; }

        [BsonElement("RacialLanguages")]
        public List<RacialLanguage> Languages {get; set;}
    }
}