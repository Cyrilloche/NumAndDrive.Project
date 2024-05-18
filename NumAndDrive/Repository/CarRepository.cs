using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly NumAndDriveContext _context;

        public CarRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<Car?> GetCarByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> CreateCarAsync(Car newCar)
        {
            await _context.Cars.AddAsync(newCar);
            await _context.SaveChangesAsync();
            return newCar;
        }

        public async Task UpdateCarAsync(Car updatedCar)
        {
            _context.Cars.Update(updatedCar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }
    }
}
