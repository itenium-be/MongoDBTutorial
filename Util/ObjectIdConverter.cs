using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MongoDBTutorial.Util
{
    /// <summary>
    /// Convert a JSON string to an <see cref="ObjectId" />
    /// </summary>
    /// <example>
    /// [JsonConverter(typeof(ObjectIdConverter))]
    /// public ObjectId Id { get; set; }
    ///
    /// JsonConvert.DeserializeObject(Of T)("json with id='c23ea232dabf49b5859582dd13b570ef'");
    /// </example>
    /// <remarks>
    /// Alternative to using this JsonConvert implementation:
    /// [BsonId]
    /// [BsonRepresentation(BsonType.ObjectId)]
    /// public string Id { get; set; }
    /// </remarks>
    public class ObjectIdConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            return new ObjectId(token.ToObject<string>());
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ObjectId);
        }
    }
}