using NumAndDrive.Models;

namespace NumAndDrive.Repository
{
    public interface IDriverTypeRepository
    {
        Task<string> GetDriverTypeByIdAsync(int? driverTypeId);

    }
}
