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

        public async Task<Filter?> GetFilterByIdAsync(int id)
        {
            return await _context.Filters.FindAsync(id);
        }

        public async Task<IEnumerable<Filter>> GetAllFiltersAsync()
        {
            return await _context.Filters.ToListAsync();
        }

        public async Task<Filter> CreateFilterAsync(Filter newFilter)
        {
            await _context.Filters.AddAsync(newFilter);
            await _context.SaveChangesAsync();
            return newFilter;
        }

        public async Task UpdateFilterAsync(Filter updatedFilter)
        {
            _context.Filters.Update(updatedFilter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFilterAsync(int id)
        {
            var filter = await _context.Filters.FindAsync(id);
            if (filter != null)
            {
                _context.Filters.Remove(filter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
