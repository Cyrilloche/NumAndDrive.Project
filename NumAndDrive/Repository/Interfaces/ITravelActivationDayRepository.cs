using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface ITravelActivationDayRepository
    {
        Task CreateNewTravelActivationDayAsync(Travel travel, List<ActivationDay> activationDays);
        Task<IEnumerable<TravelActivationDay>> GetAllTravelActivationDaysAsync();
        Task<IEnumerable<TravelActivationDay>> GetTravelActivationDaysByTravelIdAsync(Travel travel);
        Task<IEnumerable<TravelActivationDay>> GetTravelActivationDaysByActivationDayIdAsync(ActivationDay activationDay);
        Task UpdateTravelActivationDaysASync(Travel updatedTravel, List<ActivationDay> activationDays);
        Task DeleteTravelActivationDaysByTravelIdAsync(Travel deletedTravel);
    }
}
