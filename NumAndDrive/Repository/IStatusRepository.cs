using NumAndDrive.Models;

namespace NumAndDrive.Repository
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByIdAsync(int statusId);
        Task<Status> GetStatusByUserIdAsync(int userId);
    }
}
