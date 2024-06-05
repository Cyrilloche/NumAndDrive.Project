using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

public class ReservationRepository : IReservationRepository
{
    private readonly NumAndDriveContext _context;

    public ReservationRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetReservationByIdAsync(int id, string userId)
    {
        return await _context.Reservations
            .Include(r => r.Travel)
            .Where(r => r.TravelId == id && r.PassengerUserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Reservation?>> GetReservationByTravelIdAsync(int travelId)
    {
        return await _context.Reservations
            .Include(r => r.PassengerUser)
            .Include(r => r.Travel)
            .Where(t => t.TravelId == travelId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation?>> GetReservationsByUserIdAsync(string userId)
    {
        return await _context.Reservations
            .Include(r => r.Travel)
                .ThenInclude(t => t.ArrivalAddress)
            .Include(r => r.Travel)
                .ThenInclude(t => t.DepartureAddress)
            .Where(u => u.PassengerUserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation> CreateReservationAsync(Reservation newReservation)
    {
        await _context.Reservations.AddAsync(newReservation);
        await _context.SaveChangesAsync();
        return newReservation;
    }

    public async Task UpdateReservationAsync(Reservation updatedReservation)
    {
        _context.Reservations.Update(updatedReservation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }


}
