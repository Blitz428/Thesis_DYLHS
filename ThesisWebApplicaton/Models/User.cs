using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ThesisApi.Models;

namespace Thesis.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("mobile")]
        public double Mobile { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("body_data")]
        public BodyData Body_data { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonElement("birthday")]
        public DateTime Birthday { get; set; }

        [BsonElement("points")]
        public double Points { get; set; }

        [BsonElement("own_drinks")]
        public ICollection<string> Own_drinks{ get; set; }

        [BsonElement("own_ingredients")]
        public ICollection<string> Own_ingredients { get; set; }

        [BsonElement("fav_drinks")]
        public ICollection<string> Fav_drinks { get; set; }

        [BsonElement("fav_ingredients")]
        public ICollection<string> Fav_ingredients { get; set; }

        [BsonElement("friends")]
        public ICollection<string> Friends { get; set; }
    }
}
