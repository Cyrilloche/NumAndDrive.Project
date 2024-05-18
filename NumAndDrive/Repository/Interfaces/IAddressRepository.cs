using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address?> GetAddressByIdAsync(int id);
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address> CreateAddressAsync(Address newAddress);
        Task UpdateAddressAsync(Address updatedAddress);
        Task DeleteAddressAsync(int id);
    }
}
