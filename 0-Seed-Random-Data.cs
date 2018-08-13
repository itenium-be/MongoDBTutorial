using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MongoDBTutorial.Models;
using MongoDBTutorial.Util;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MongoDBTutorial
{
    /// <summary>
    /// Inserts some data in MongoDb (persons)
    /// Adjust credentials in appsettings.json
    /// </summary>
    public class SeedRandomData
    {
        [Ignore("Should be run only once probably")]
        [Test]
        public async Task SeedPersons()
        {
            var sets = MongoConnectionSettings.Get();
            var client = new MongoClient(sets.GetConnectionString());
            var database = client.GetDatabase(sets.Database);

            string GetFileContent(string p) => File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Seed", p));

            // Data generated with https://mockaroo.com/
            database.DropCollection("persons");
            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(GetFileContent("persons.json"));
            var db = database.GetCollection<Person>("persons");
            await db.InsertManyAsync(persons);
        }
    }
}
