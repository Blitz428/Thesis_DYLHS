using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.ObjectModel;

namespace Thesis.Models
{
    public class Drink
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("created_by")]
        public string Created_by { get; set; }


        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

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

        [BsonElement("avg_rating")]
        public double Avg_rating { get; set; }

        [BsonElement("verified")]
        public bool Verified { get; set; }

        [BsonElement("ingredients")]
        public ObservableCollection<string> Ingredients { get; set; }

        [BsonElement("ratings")]
        public ObservableCollection<string> Ratings { get; set; }


    }
}
