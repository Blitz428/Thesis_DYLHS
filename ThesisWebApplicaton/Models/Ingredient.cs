using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Thesis.Models
{
    public class Ingredient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("created_by")]
        public string Created_by { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("alcohol")]
        public double Alcohol { get; set; }

        [BsonElement("kcal")]
        public double Kcal { get; set; }

        [BsonElement("fat")]
        public double Fat { get; set; }

        [BsonElement("protein")]
        public double Protein { get; set; }

        [BsonElement("carbon")]
        public double Carbon { get; set; }

        [BsonElement("verified")]
        public bool Verified { get; set; }

        [BsonElement("avg_rating")]
        public double Avg_rating { get; set; }

    }
}
