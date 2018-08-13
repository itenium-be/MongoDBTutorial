using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBTutorial.Models;
using MongoDBTutorial.Util;
using NUnit.Framework;

namespace MongoDBTutorial
{
    /// <summary>
    /// These test assume that SeedRandomData.SeedPersons() has run.
    /// </summary>
    public class Basics
    {
        private IMongoCollection<Person> _col;

        [SetUp]
        public void Setup()
        {
            var sets = MongoConnectionSettings.Get();
            var client = new MongoClient(sets.GetConnectionString());
            var database = client.GetDatabase(sets.Database);
            _col = database.GetCollection<Person>("persons");
        }

        [Test]
        public async Task GetAll()
        {
            var lst = await _col.Find(x => true).ToListAsync();
            Assert.That(lst.Count, Is.EqualTo(1000));
        }
    }

    //public async Task<IEnumerable<Product>> GetAll()
    //{
    //    return await _context.Products.Find(x => !x.Deleted).ToListAsync();
    //}


    //public async Task UpdateViewCount(string productId)
    //{
    //    var increaseViews = Builders<ProductViews>.Update.Inc("views", 1);
    //    await _context.ProductViews.UpdateOneAsync(view => view.ProductId == productId, increaseViews);
    //}

    //public async Task<Product> CreateOrUpdate(Product prod)
    //{
    //    //var update = Builders<Product>.Update.CurrentDate("lastModified");
    //    await _context.Products.ReplaceOneAsync(product => product.Id == prod.Id, prod, new UpdateOptions() { IsUpsert = true }, CancellationToken.None);
    //    return prod;
    //}
}