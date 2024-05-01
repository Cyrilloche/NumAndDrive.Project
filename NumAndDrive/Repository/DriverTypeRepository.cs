
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;

namespace NumAndDrive.Repository
{
    public class DriverTypeRepository : IDriverTypeRepository
    {
        private readonly NumAndDriveContext _context;

        public DriverTypeRepository(NumAndDriveContext context)
        {
            _context = context;
        }
        public async Task<string> GetDriverTypeByIdAsync(int? driverTypeId)
        {
            var driverType = await _context.DriverTypes.FirstOrDefaultAsync(dp => dp.DriverTypeId == driverTypeId);

            return driverType.Name ?? "";
        }
    }
}
