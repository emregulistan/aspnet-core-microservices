using Advert.API.Entities.Concrete;
using MongoDB.Driver;

namespace Advert.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Car> carCollection)
        {
            bool existProduct = carCollection.Find(p => true).Any();
            if (!existProduct)
            {
                carCollection.InsertManyAsync(GetPreconfiguredCars());
            }
        }

        private static IEnumerable<Car> GetPreconfiguredCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Title = "Fait Agea",
                    BrandId = 1,
                    ModelYear = 2017,
                    Descriptions = "A good car",
                    ColorId = 2,
                    Price = 950.00M,
                    IsSold = false,
                },
                new Car()
                {
                    Id = "602d2149e773f2a399244242",
                    Title = "Renolt Clia",
                    BrandId = 2,
                    ModelYear = 2015,
                    Descriptions = "A very good car",
                    ColorId = 3,
                    Price = 450.00M,
                    IsSold = false,
                },
                new Car()
                {
                    Id = "602d2149e773f2a391244242",
                    Title = "Paguet 301",
                    BrandId = 3,
                    ModelYear = 2019,
                    Descriptions = "A very very good car",
                    ColorId = 4,
                    Price = 350.00M,
                    IsSold = false,
                },
            };
        }
    }
}
