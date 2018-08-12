using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MongoDBTutorial.Util;
using NUnit.Framework;

namespace MongoDBTutorial
{
    /// <summary>
    /// Inserts some data in MongoDb
    /// </summary>
    public class SeedRandomData
    {
        [Test]
        public void SeedData()
        {
            var sets = MongoConnectionSettings.Get();

            var client = new MongoClient(sets.GetConnectionString());
            var database = client.GetDatabase(sets.Database);

            database.CreateCollection("test-seed");

            //database.GetCollection<SeedRandomData>("categories");


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
}
