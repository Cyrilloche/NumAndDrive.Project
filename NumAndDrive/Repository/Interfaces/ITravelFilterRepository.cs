using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface ITravelFilterRepository
    {
        Task CreateNewTravelFilterAsync(Travel newTravel, List<Filter> filters);
        Task<IEnumerable<TravelFilter>> GetAllTravelFiltersAsync();
        Task<IEnumerable<TravelFilter>> GetTravelFiltersByTravelIdAsync(Travel travel);
        Task<IEnumerable<TravelFilter>> GetTravelFiltersByFilterIdAsync(Filter filter);
        Task UpdateTravelFilterASync(Travel updatedTravel, List<Filter> filters);
        Task DeleteTravelFilterByTravelIdAsync(Travel deletedTravel);
    }
}
