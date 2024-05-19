using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly NumAndDriveContext _context;

        public AddressRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<Address?> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> CreateAddressAsync(Address newAddress)
        {
            await _context.Addresses.AddAsync(newAddress);
            await _context.SaveChangesAsync();
            return newAddress;
        }

        public async Task UpdateAddressAsync(Address updatedAddress)
        {
            _context.Addresses.Update(updatedAddress);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
