using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class TravelRepository : ITravelRepository
    {
        private readonly NumAndDriveContext _context;

        public TravelRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<Travel?> GetTravelByIdAsync(int id)
        {
            return await _context.Travels.FindAsync(id);
        }

        public async Task<IEnumerable<Travel>> GetAllTravelsAsync()
        {
            return await _context.Travels.ToListAsync();
        }

        public async Task<Travel> CreateTravelAsync(Travel newTravel)
        {
            await _context.Travels.AddAsync(newTravel);
            await _context.SaveChangesAsync();
            return newTravel;
        }

        public async Task UpdateTravelAsync(Travel updatedTravel)
        {
            _context.Travels.Update(updatedTravel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTravelAsync(int id)
        {
            var travel = await _context.Travels.FindAsync(id);
            if (travel != null)
            {
                _context.Travels.Remove(travel);
                await _context.SaveChangesAsync();
            }
        }

        async Task<IEnumerable<Travel>> ITravelRepository.GetTravelsByPublisherId(string userId)
        {
            return await _context.Travels.Where(u => u.PublisherUserId == userId).ToListAsync();
        }
    }
}
