using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

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
        public int Ratings {  get; set; }

    }
}
