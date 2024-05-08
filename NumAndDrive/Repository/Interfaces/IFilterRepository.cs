using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IFilterRepository
    {
        Task<IEnumerable<Filter>> GetAllFiltersAsync();
    }
}
