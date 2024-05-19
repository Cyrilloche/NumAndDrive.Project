using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

public class UserTravelPreferenceRepository : IUserTravelPreferenceRepository
{
    private readonly NumAndDriveContext _context;

    public UserTravelPreferenceRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<UserTravelPreference?> GetUserTravelPreferenceByIdAsync(int id)
    {
        return await _context.UserTravelPreferences.FindAsync(id);
    }

    public async Task<IEnumerable<UserTravelPreference>> GetAllUserTravelPreferencesAsync()
    {
        return await _context.UserTravelPreferences.ToListAsync();
    }

    public async Task<UserTravelPreference> CreateUserTravelPreferenceAsync(UserTravelPreference newUserTravelPreference)
    {
        await _context.UserTravelPreferences.AddAsync(newUserTravelPreference);
        await _context.SaveChangesAsync();
        return newUserTravelPreference;
    }

    public async Task UpdateUserTravelPreferenceAsync(UserTravelPreference updatedUserTravelPreference)
    {
        _context.UserTravelPreferences.Update(updatedUserTravelPreference);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserTravelPreferenceAsync(int id)
    {
        var userTravelPreference = await _context.UserTravelPreferences.FindAsync(id);
        if (userTravelPreference != null)
        {
            _context.UserTravelPreferences.Remove(userTravelPreference);
            await _context.SaveChangesAsync();
        }
    }
}
