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

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<string> GetStatusByIdAsync(int? statusId)
        {
            var status = await _context.Statuses.FirstOrDefaultAsync(s => s.StatusId == statusId);
            if (status != null) return status.Name;
            return " ";
        }
    }
}
