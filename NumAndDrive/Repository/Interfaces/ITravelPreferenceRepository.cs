using NumAndDrive.Models;

public interface ITravelPreferenceRepository
{
    Task<TravelPreference?> GetTravelPreferenceByIdAsync(int id);
    Task<IEnumerable<TravelPreference>> GetAllTravelPreferencesAsync();
    Task<TravelPreference> CreateTravelPreferenceAsync(TravelPreference newTravelPreference);
    Task UpdateTravelPreferenceAsync(TravelPreference updatedTravelPreference);
    Task DeleteTravelPreferenceAsync(int id);
}
