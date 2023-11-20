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
        public string? _Id { get; set; }

        public string Created_by { get; set; }

        public string Drink_name { get; set; }

        public string Description { get; set; }

        public enum Type { type1, type2, type3, type4 }

        public double Alcohol { get; set; }

        public int Kcal {  get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double Carbon { get; set; }

        public double Avg_rating { get; set; }

        public bool Verified { get; set; }

        public DateTime Timestamp {  get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Rating> Ratings { get; set; }


    }
}
