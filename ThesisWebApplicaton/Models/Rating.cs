using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Thesis.Models
{
    public class Rating
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("created_by")]
        public string Created_by { get; set; }

        [BsonElement("review")]
        public string Review { get; set; }

        [BsonElement("rating")]
        public int Ratings { get; set; }

    }
}
