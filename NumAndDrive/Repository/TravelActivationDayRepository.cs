using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class TravelActivationDayRepository : ITravelActivationDayRepository
    {
        private readonly NumAndDriveContext _context;
        private readonly ITravelRepository _travelRepository;

        public TravelActivationDayRepository(NumAndDriveContext context, ITravelRepository travelRepository)
        {
            _context = context;
            _travelRepository = travelRepository;
        }

        public async Task CreateNewTravelActivationDayAsync(Travel newTravel, List<ActivationDay> activationDays)
        {
            if (activationDays != null)
            {
                foreach (var day in activationDays)
                {
                    if (day.IsSelected == true)
                    {
                        TravelActivationDay newTravelActivationDay = new TravelActivationDay
                        {
                            ActivationDayId = day.ActivationDayId,
                            TravelId = newTravel.TravelId
                        };
                        await _context.TravelActivationDays.AddAsync(newTravelActivationDay);
                    }
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TravelActivationDay>> GetAllTravelActivationDaysAsync()
        {
            return await _context.TravelActivationDays.ToListAsync();
        }

        public async Task<IEnumerable<TravelActivationDay>> GetTravelActivationDaysByActivationDayIdAsync(ActivationDay activationDay)
        {
            return await _context.TravelActivationDays.Where(ad => ad.ActivationDayId == activationDay.ActivationDayId).ToListAsync();
        }

        public async Task<IEnumerable<TravelActivationDay>> GetTravelActivationDaysByTravelIdAsync(Travel travel)
        {
            return await _context.TravelActivationDays.Where(t => t.TravelId == travel.TravelId).ToListAsync();
        }

        public async Task DeleteTravelActivationDaysByTravelIdAsync(Travel deletedTravel)
        {
            IEnumerable<TravelActivationDay> travelActivationDays = await GetTravelActivationDaysByTravelIdAsync(deletedTravel);

            _context.TravelActivationDays.RemoveRange(travelActivationDays);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTravelActivationDaysASync(Travel updatedTravel, List<ActivationDay> activationDays)
        {
            if (updatedTravel.TravelActivationDays != null)
            {
                List<TravelActivationDay> travelFilters = new List<TravelActivationDay>();
                foreach (var day in activationDays)
                {
                    TravelActivationDay newTravelActivationDay = new TravelActivationDay
                    {
                        ActivationDayId = day.ActivationDayId,
                        TravelId = updatedTravel.TravelId
                    };

                    travelFilters.Add(newTravelActivationDay);
                }
                await DeleteTravelActivationDaysByTravelIdAsync(updatedTravel);
                await CreateNewTravelActivationDayAsync(updatedTravel, activationDays);
            }
        }
    }
}
