using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Thesis.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public enum Role { role1,role2 }
        public int Mobile {  get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }
        public int Points { get; set; }
        public bool Gender { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
    }
}
