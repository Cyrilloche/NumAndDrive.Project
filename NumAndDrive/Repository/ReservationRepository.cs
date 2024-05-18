using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ReservationRepository : IReservationRepository
{
    private readonly NumAndDriveContext _context;

    public ReservationRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetReservationByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
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
