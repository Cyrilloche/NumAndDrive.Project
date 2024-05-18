using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IActivationDayRepository
    {
        Task<ActivationDay?> GetActivationDayByIdAsync(int id);
        Task<IEnumerable<ActivationDay>> GetAllActivationDaysAsync();
        Task<ActivationDay> CreateActivationDayAsync(ActivationDay newActivationDay);
        Task UpdateActivationDayAsync(ActivationDay updatedActivationDay);
        Task DeleteActivationDayAsync(int id);
    }
}
