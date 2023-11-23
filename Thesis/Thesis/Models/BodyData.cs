using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Core.Operations;

namespace ThesisApi.Models
{
    public class BodyData
    {
        [BsonElement("gender")]
        public bool Gender { get; set; }

        [BsonElement("weight")]
        public double Weight { get; set; }

        [BsonElement("height")]
        public double Height { get; set; }

        public BodyData(bool gender, double weight, double height)
        {
            this.Weight = weight;
            this.Height = height;
            this.Gender = gender;
        }

    }
}
