using Advert.API.Entities.Concrete;
using MongoDB.Driver;

namespace Advert.API.Data
{ 
    public class CatalogContext
    {
    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Cars = database.GetCollection<Car>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        CatalogContextSeed.SeedData(Cars);
    }

    public IMongoCollection<Car> Cars { get; }
}
}