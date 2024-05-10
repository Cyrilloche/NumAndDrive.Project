using NumAndDrive.Models;

namespace NumAndDrive.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddressAsync();
        Task<Address> GetAddressByIdAsync(int addressId);
        Task<Address> CreateNewAdressAsync(Address newAddress);
        Task UpdateAddressAsync(Address updatedAddress);
        Task DeleteAddressAsync(int id);
    }
}
