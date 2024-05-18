using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TravelStopPointRepository : ITravelStopPointRepository
{
    private readonly NumAndDriveContext _context;

    public TravelStopPointRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<TravelStopPoint?> GetTravelStopPointByIdAsync(int id)
    {
        return await _context.TravelStopPoints.FindAsync(id);
    }

    public async Task<IEnumerable<TravelStopPoint>> GetAllTravelStopPointsAsync()
    {
        return await _context.TravelStopPoints.ToListAsync();
    }

    public async Task<TravelStopPoint> CreateTravelStopPointAsync(TravelStopPoint newTravelStopPoint)
    {
        await _context.TravelStopPoints.AddAsync(newTravelStopPoint);
        await _context.SaveChangesAsync();
        return newTravelStopPoint;
    }

    public async Task UpdateTravelStopPointAsync(TravelStopPoint updatedTravelStopPoint)
    {
        _context.TravelStopPoints.Update(updatedTravelStopPoint);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTravelStopPointAsync(int id)
    {
        var travelStopPoint = await _context.TravelStopPoints.FindAsync(id);
        if (travelStopPoint != null)
        {
            _context.TravelStopPoints.Remove(travelStopPoint);
            await _context.SaveChangesAsync();
        }
    }
}
