using NumAndDrive.Models;

namespace NumAndDrive.Repository
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByUserIdAsync(int? statusId);
    }
}
