using NumAndDrive.Models;

public interface IReservationRepository
{
    Task<Reservation?> GetReservationByIdAsync(int id);
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
    Task<Reservation> CreateReservationAsync(Reservation newReservation);
    Task UpdateReservationAsync(Reservation updatedReservation);
    Task DeleteReservationAsync(int id);
    Task<IEnumerable<Reservation?>> GetReservationByTravelIdAsync(int travelId);
}
