using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByUserIdAsync(int? statusId);
    }
}
