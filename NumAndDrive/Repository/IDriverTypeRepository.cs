using NumAndDrive.Models;

namespace NumAndDrive.Repository
{
    public interface IDriverTypeRepository
    {
        Task<DriverType> GetDriverTypeByUserIdAsync(int? driverTypeId);

    }
}
