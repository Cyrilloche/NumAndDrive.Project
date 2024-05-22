using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class ActivationDayRepository : IActivationDayRepository
    {
        private readonly NumAndDriveContext _context;

        public ActivationDayRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<ActivationDay?> GetActivationDayByIdAsync(int id)
        {
            return await _context.ActivationDays.FindAsync(id);
        }

        public async Task<IEnumerable<ActivationDay>> GetAllActivationDaysAsync()
        {
            return await _context.ActivationDays
                .Include(ad => ad.TravelActivationDays)
                .ToListAsync();
        }

        public async Task<ActivationDay> CreateActivationDayAsync(ActivationDay newActivationDay)
        {
            await _context.ActivationDays.AddAsync(newActivationDay);
            await _context.SaveChangesAsync();
            return newActivationDay;
        }

        public async Task UpdateActivationDayAsync(ActivationDay updatedActivationDay)
        {
            _context.ActivationDays.Update(updatedActivationDay);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActivationDayAsync(int id)
        {
            var activationDay = await _context.ActivationDays.FindAsync(id);
            if (activationDay != null)
            {
                _context.ActivationDays.Remove(activationDay);
                await _context.SaveChangesAsync();
            }
        }
    }
}
