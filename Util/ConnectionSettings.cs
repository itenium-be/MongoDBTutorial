using System.IO;
using Newtonsoft.Json;

namespace MongoDBTutorial.Util
{
    public class MongoConnectionSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }

        public static MongoConnectionSettings Get()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var result = JsonConvert.DeserializeObject<MongoConnectionSettings>(File.ReadAllText(path));
            return result;
        }

        public string GetConnectionString()
        {
            return $"mongodb://{Server}:{Port}";
        }

        public override string ToString() => $"{Server}:{Port}/{Database}";
    }
}