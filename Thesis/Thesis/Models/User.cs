using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using ThesisApi.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class User : INotifyPropertyChanged  
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }
        
        [BsonIgnore]
        private string username;

        [BsonElement("username")]
        public string Username { get =>username; set { username = value; NotifyPropertyChanged(); } }

        [BsonIgnore]
        private string password;

        [BsonElement("password")]
        public string Password { get => password; set { password = value; NotifyPropertyChanged(); } }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
