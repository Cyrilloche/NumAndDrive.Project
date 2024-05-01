using NumAndDrive.Models;

namespace NumAndDrive.Repository
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<string> GetStatusByIdAsync(int? statusId);
    }
}
