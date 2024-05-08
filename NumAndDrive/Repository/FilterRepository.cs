using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class FilterRepository : IFilterRepository
    {
        private readonly NumAndDriveContext _context;

        public FilterRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filter>> GetAllFiltersAsync()
        {
            return await _context.Filters.ToListAsync();
        }
    }
}
