using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Thesis.Models
{
    public class Drink
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("created_by")]
        public string Created_by { get; set; }


        [BsonElement("drink_name")]
        public string Drink_name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        public string Type { get; set; }

        [BsonElement("alcohol")]
        public double Alcohol { get; set; }

        [BsonElement("kcal")]
        public double Kcal {  get; set; }

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

       
        public ICollection<string> Ingredients { get; set; }

  
        public ICollection<string> Ratings { get; set; }


    }
}
