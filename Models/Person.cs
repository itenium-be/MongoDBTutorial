using MongoDB.Bson;
using MongoDBTutorial.Util;
using Newtonsoft.Json;

namespace MongoDBTutorial.Models
{
    public class Person
    {
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Ip { get; set; }

        public override string ToString() => $"{FirstName} {LastName} ({Gender})";
    }
}