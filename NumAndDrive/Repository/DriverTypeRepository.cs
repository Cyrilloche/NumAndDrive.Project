
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class DriverTypeRepository : IDriverTypeRepository
    {
        private readonly NumAndDriveContext _context;

        public DriverTypeRepository(NumAndDriveContext context)
        {
            _context = context;
        }
        public async Task<DriverType?> GetDriverTypeByIdAsync(int? id)
        {
            return await _context.DriverTypes.FindAsync(id);
        }

        public async Task<IEnumerable<DriverType>> GetAllDriverTypesAsync()
        {
            return await _context.DriverTypes.ToListAsync();
        }

        public async Task<DriverType> CreateDriverTypeAsync(DriverType newDriverType)
        {
            await _context.DriverTypes.AddAsync(newDriverType);
            await _context.SaveChangesAsync();
            return newDriverType;
        }

        public async Task UpdateDriverTypeAsync(DriverType updatedDriverType)
        {
            _context.DriverTypes.Update(updatedDriverType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDriverTypeAsync(int id)
        {
            var driverType = await _context.DriverTypes.FindAsync(id);
            if (driverType != null)
            {
                _context.DriverTypes.Remove(driverType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
