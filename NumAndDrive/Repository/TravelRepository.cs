using Microsoft.AspNetCore.Identity;
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

        public async Task<Travel> CreateNewTravelAsync(Travel newTravel)
        {
            await _context.Travels.AddAsync(newTravel);
            await _context.SaveChangesAsync();
            return newTravel;

        }

        public async Task DeleteTravelASync(int id)
        {
            Travel travel = await GetTravelByIdAsync(id);
            if(travel != null)
            {
                _context.Travels.Remove(travel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Travel>> GetAllTravelsAsync()
        {
            return await _context.Travels.ToListAsync();
        }

        public async Task<Travel> GetTravelByIdAsync(int id)
        {
            return await _context.Travels.FirstOrDefaultAsync(t => t.TravelId == id) ?? new Travel();
        }

        public async Task UpdateTravelASync(Travel updatedTravel)
        {
            _context.Update(updatedTravel);
            await _context.SaveChangesAsync();
        }

        async Task<IEnumerable<Travel>> ITravelRepository.GetTravelsByPublisherId(string userId)
        {
            return await _context.Travels.Where(u => u.PublisherUserId == userId).ToListAsync();
        }
    }
}
