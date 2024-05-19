using NumAndDrive.Models;

public interface IUserTravelPreferenceRepository
{
    Task<UserTravelPreference?> GetUserTravelPreferenceByIdAsync(int id);
    Task<IEnumerable<UserTravelPreference>> GetAllUserTravelPreferencesAsync();
    Task<UserTravelPreference> CreateUserTravelPreferenceAsync(UserTravelPreference newUserTravelPreference);
    Task UpdateUserTravelPreferenceAsync(UserTravelPreference updatedUserTravelPreference);
    Task DeleteUserTravelPreferenceAsync(int id);
}
