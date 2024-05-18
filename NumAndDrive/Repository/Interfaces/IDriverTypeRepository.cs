using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IDriverTypeRepository
    {
        Task<IEnumerable<DriverType>> GetAllDriverTypesAsync();
        Task<DriverType?> GetDriverTypeByIdAsync(int? id);
        Task<DriverType> CreateDriverTypeAsync(DriverType newDriverType);
        Task UpdateDriverTypeAsync(DriverType updatedDriverType);
        Task DeleteDriverTypeAsync(int id);

    }
}
