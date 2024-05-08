using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class ActivationDayRepository : IActivationDayRepository
    {
        private readonly NumAndDriveContext _context;

        public ActivationDayRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivationDay>> GetActivationDays()
        {
            return await _context.ActivationDays.ToListAsync();
        }
    }
}
