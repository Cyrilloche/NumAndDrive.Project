using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IFilterRepository
    {
        Task<Filter?> GetFilterByIdAsync(int id);
        Task<IEnumerable<Filter>> GetAllFiltersAsync();
        Task<Filter> CreateFilterAsync(Filter newFilter);
        Task UpdateFilterAsync(Filter updatedFilter);
        Task DeleteFilterAsync(int id);
    }
}
