using Advert.API.Data;
using Advert.API.Entities.Concrete;
using Advert.API.Repositories.Abstract;
using MongoDB.Driver;

namespace Advert.API.Repositories.Concrete
{
    public class CarRepository : ICarRepository
    {
        private readonly CatalogContext _context;

        public CarRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            return await _context
                            .Cars
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<Car> GetCar(string id)
        {
            return await _context
                           .Cars
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetCarByTitle(string title)
        {
            FilterDefinition<Car> filter = Builders<Car>.Filter.Eq(p => p.Title, title);

            return await _context
                            .Cars
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateCar(Car car)
        {
            await _context.Cars.InsertOneAsync(car);
        }

        public async Task<bool> UpdateCar(Car car)
        {
            var updateResult = await _context
                                        .Cars
                                        .ReplaceOneAsync(filter: g => g.Id == car.Id, replacement: car);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteCar(string id)
        {
            FilterDefinition<Car> filter = Builders<Car>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Cars
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

    }
}
