using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

public class FuelRepository : IFuelRepository
{
    private readonly NumAndDriveContext _context;

    public FuelRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<Fuel?> GetFuelByIdAsync(int id)
    {
        return await _context.Fuels.FindAsync(id);
    }

    public async Task<IEnumerable<Fuel>> GetAllFuelsAsync()
    {
        return await _context.Fuels.ToListAsync();
    }

    public async Task<Fuel> CreateFuelAsync(Fuel newFuel)
    {
        await _context.Fuels.AddAsync(newFuel);
        await _context.SaveChangesAsync();
        return newFuel;
    }

    public async Task UpdateFuelAsync(Fuel updatedFuel)
    {
        _context.Fuels.Update(updatedFuel);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFuelAsync(int id)
    {
        var fuel = await _context.Fuels.FindAsync(id);
        if (fuel != null)
        {
            _context.Fuels.Remove(fuel);
            await _context.SaveChangesAsync();
        }
    }
}
