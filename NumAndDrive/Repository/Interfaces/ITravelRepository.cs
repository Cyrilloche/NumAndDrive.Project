using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface ITravelRepository
    {
        Task<Travel> CreateTravelAsync(Travel newTravel);
        Task<Travel> GetTravelByIdAsync(int id);
        Task<IEnumerable<Travel>> GetAllTravelsAsync();
        Task DeleteTravelAsync(int id);
        Task UpdateTravelAsync(Travel updatedTravel);
        Task<IEnumerable<Travel>> GetTravelsByPublisherId(string userId);
    }
}
