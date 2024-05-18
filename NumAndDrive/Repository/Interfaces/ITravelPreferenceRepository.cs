using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITravelPreferenceRepository
{
    Task<TravelPreference?> GetTravelPreferenceByIdAsync(int id);
    Task<IEnumerable<TravelPreference>> GetAllTravelPreferencesAsync();
    Task<TravelPreference> CreateTravelPreferenceAsync(TravelPreference newTravelPreference);
    Task UpdateTravelPreferenceAsync(TravelPreference updatedTravelPreference);
    Task DeleteTravelPreferenceAsync(int id);
}
