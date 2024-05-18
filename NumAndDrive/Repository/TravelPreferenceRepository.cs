using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TravelPreferenceRepository : ITravelPreferenceRepository
{
    private readonly NumAndDriveContext _context;

    public TravelPreferenceRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<TravelPreference?> GetTravelPreferenceByIdAsync(int id)
    {
        return await _context.TravelPreferences.FindAsync(id);
    }

    public async Task<IEnumerable<TravelPreference>> GetAllTravelPreferencesAsync()
    {
        return await _context.TravelPreferences.ToListAsync();
    }

    public async Task<TravelPreference> CreateTravelPreferenceAsync(TravelPreference newTravelPreference)
    {
        await _context.TravelPreferences.AddAsync(newTravelPreference);
        await _context.SaveChangesAsync();
        return newTravelPreference;
    }

    public async Task UpdateTravelPreferenceAsync(TravelPreference updatedTravelPreference)
    {
        _context.TravelPreferences.Update(updatedTravelPreference);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTravelPreferenceAsync(int id)
    {
        var travelPreference = await _context.TravelPreferences.FindAsync(id);
        if (travelPreference != null)
        {
            _context.TravelPreferences.Remove(travelPreference);
            await _context.SaveChangesAsync();
        }
    }
}
