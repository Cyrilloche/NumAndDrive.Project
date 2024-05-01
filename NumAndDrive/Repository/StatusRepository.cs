using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository;

namespace NumAndDrive.Services
{
    public class StatusRepository : IStatusRepository
    {
        private readonly NumAndDriveContext _context;
        public StatusRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int statusId)
        {
            return await _context.Statuses.FirstOrDefaultAsync(s => s.StatusId == statusId);
        }

    }
}
