using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IDriverTypeRepository
    {
        Task<DriverType> GetDriverTypeByUserIdAsync(int? driverTypeId);
        Task<IEnumerable<DriverType>> GetAllDriverTypesAsync();

    }
}
