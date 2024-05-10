using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IActivationDayRepository
    {
        Task<IEnumerable<ActivationDay>> GetActivationDaysAsync();
    }
}
