using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface ICarRepository
    {
        Task<Car?> GetCarByIdAsync(int id);
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> CreateCarAsync(Car newCar);
        Task UpdateCarAsync(Car updatedCar);
        Task DeleteCarAsync(int id);
    }
}
