﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using ThesisApi.Models;

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
        public string Username { get => username; set { username = value; } }

        [BsonIgnore]
        private string password;

        [BsonElement("password")]
        public string Password { get => password; set { password = value; } }

        [BsonElement("mobile")]
        public double Mobile { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("body_data")]
        public BodyData Body_data { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonElement("points")]
        public double Points { get; set; }

        [BsonElement("birthday")]
        public DateTime Birthday { get; set; }

        [BsonElement("own_drinks")]
        public ICollection<string> Own_drinks { get; set; }

        [BsonElement("own_ingredients")]
        public ICollection<string> Own_ingredients { get; set; }

        [BsonElement("fav_drinks")]
        public ICollection<string> Fav_drinks { get; set; }

        [BsonElement("fav_ingredients")]
        public ICollection<string> Fav_ingredients { get; set; }

        [BsonElement("friends")]
        public ICollection<string> Friends { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static string EncryptPassword(string password)
        {
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
            ICryptoTransform encryptor = rc2CSP.CreateEncryptor(rc2CSP.IV, rc2CSP.Key);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    byte[] toEncrypt = Encoding.Unicode.GetBytes(password);

                    csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                    csEncrypt.FlushFinalBlock();

                    byte[] encrypted = msEncrypt.ToArray();

                    return Convert.ToBase64String(encrypted);
                }
            }
        }
        public static string DecryptPassword(string password)
        {
            RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
            ICryptoTransform decryptor = rc2CSP.CreateDecryptor(rc2CSP.Key, rc2CSP.IV);
            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(password)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    List<Byte> bytes = new List<byte>();
                    int b;
                    do
                    {
                        b = csDecrypt.ReadByte();
                        if (b != -1)
                        {
                            bytes.Add(Convert.ToByte(b));
                        }

                    }
                    while (b != -1);

                    return Encoding.Unicode.GetString(bytes.ToArray());
                }
            }
        }

    }
}
