﻿using MongoDB.Bson.Serialization.Attributes;

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

        public BodyData()
        {

        }

    }
}
