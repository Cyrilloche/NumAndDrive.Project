using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using System.Collections.Generic;

namespace NumAndDrive.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly NumAndDriveContext _context;

        public AddressRepository(NumAndDriveContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateNewAdressAsync(Address newAddress)
        {
            await _context.Addresses.AddAsync(newAddress);
            await _context.SaveChangesAsync();
            return newAddress;
        }

        public async Task DeleteAddressAsync(int id)
        {
            Address address = await GetAddressByIdAsync(id);
            if(address != null)
            {
                _context.Remove(address);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Address> GetAddressByIdAsync(int addressId)
        {
            return await _context.Addresses.FirstOrDefaultAsync(a => a.AddressId == addressId) ?? new Address();
        }

        public async Task<IEnumerable<Address>> GetAllAddressAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task UpdateAddressAsync(Address updatedAddress)
        {
            _context.Addresses.Update(updatedAddress);
            await _context.SaveChangesAsync();
        }
    }
}
