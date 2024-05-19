using NumAndDrive.Models;

public interface IFuelRepository
{
    Task<Fuel?> GetFuelByIdAsync(int id);
    Task<IEnumerable<Fuel>> GetAllFuelsAsync();
    Task<Fuel> CreateFuelAsync(Fuel newFuel);
    Task UpdateFuelAsync(Fuel updatedFuel);
    Task DeleteFuelAsync(int id);
}
