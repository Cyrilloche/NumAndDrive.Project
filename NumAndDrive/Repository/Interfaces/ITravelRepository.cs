using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface ITravelRepository
    {
        Task<Travel> CreateNewTravelAsync(Travel newTravel);
        Task<Travel> GetTravelByIdAsync(int id);
        Task<IEnumerable<Travel>> GetAllTravelsAsync();
        Task DeleteTravelASync(int id);
        Task UpdateTravelASync(Travel updatedTravel);
        Task<IEnumerable<Travel>> GetTravelsByPublisherId(string userId);

    }
}
