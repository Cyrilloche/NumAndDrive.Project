using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class TravelFilterRepository : ITravelFilterRepository
    {
        private readonly NumAndDriveContext _context;

        public TravelFilterRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task CreateNewTravelFilterAsync(Travel newTravel, List<Filter> filters)
        {
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    if (filter.IsSelected == true)
                    {
                        TravelFilter newTravelFilter = new TravelFilter
                        {
                            TravelId = newTravel.TravelId,
                            FilterId = filter.FilterId
                        };
                        await _context.TravelFilters.AddAsync(newTravelFilter);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTravelFilterByTravelIdAsync(Travel deletedTravel)
        {
            IEnumerable<TravelFilter> travelFilters = await GetTravelFiltersByTravelIdAsync(deletedTravel);

            _context.TravelFilters.RemoveRange(travelFilters);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TravelFilter>> GetAllTravelFiltersAsync()
        {
            return await _context.TravelFilters.ToListAsync();
        }

        public async Task<IEnumerable<TravelFilter>> GetTravelFiltersByFilterIdAsync(Filter filter)
        {
            return await _context.TravelFilters.Where(f => f.FilterId == filter.FilterId).ToListAsync();
        }

        public async Task<IEnumerable<TravelFilter>> GetTravelFiltersByTravelIdAsync(Travel travel)
        {
            return await _context.TravelFilters.Where(t => t.TravelId == travel.TravelId).ToListAsync();
        }

        public async Task UpdateTravelFilterASync(Travel updatedTravel, List<Filter> filters)
        {
            if (filters != null)
            {
                await DeleteTravelFilterByTravelIdAsync(updatedTravel);
                await CreateNewTravelFilterAsync(updatedTravel, filters);
            }
        }
    }
}
