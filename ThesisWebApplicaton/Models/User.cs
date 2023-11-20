using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
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
        public double Mobile {  get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("body_data")]
        public BodyData Body_data { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonElement("points")]
        public double Points { get; set; }

    }
}
