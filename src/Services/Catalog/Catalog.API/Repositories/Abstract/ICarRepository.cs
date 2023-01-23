using Advert.API.Entities.Concrete;

namespace Advert.API.Repositories.Abstract
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetCar(string id);
        Task<IEnumerable<Car>> GetCarByTitle(string title);
        Task CreateCar(Car car);
        Task<bool> UpdateCar(Car car);
        Task<bool> DeleteCar(string id);

    }
}
