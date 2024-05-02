
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

namespace NumAndDrive.Repository
{
    public class DriverTypeRepository : IDriverTypeRepository
    {
        private readonly NumAndDriveContext _context;

        public DriverTypeRepository(NumAndDriveContext context)
        {
            _context = context;
        }
        public async Task<DriverType> GetDriverTypeByUserIdAsync(int? driverTypeId)
        {
            return await _context.DriverTypes.FirstOrDefaultAsync(dp => dp.DriverTypeId == driverTypeId);

        }

        public async Task<IEnumerable<DriverType>> GetAllDriverTypesAsync()
        {
            return await _context.DriverTypes.ToListAsync();
        }
    }
}
