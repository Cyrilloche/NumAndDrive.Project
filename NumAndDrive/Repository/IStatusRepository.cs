using NumAndDrive.Models;

namespace NumAndDrive.Repository
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task<Status> GetStatusByIdAsync(int statusId);
    }
}
