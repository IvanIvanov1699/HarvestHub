using HarvestHub.Context;
using HarvestHub.DTOs;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDBContext _context;

        public AddressRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Address> CreateAddressAsync(AddressDTO dto)
        {
            var newAddress = new Address()
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Province = dto.Province,
                City = dto.City,
                PostalCode = dto.PostalCode,
                StreetAddress = dto.StreetAddress,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                ExtraInfo = dto.ExtraInfo,
                UserName = dto.UserName,
            };

            await _context.Addresses.AddAsync(newAddress);
            await _context.SaveChangesAsync();
            return newAddress;
        }

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<List<Address>> GetAddressesByUserNameAsync(string userName)
        {
            return await _context.Addresses
                .Where(i => i.UserName == userName)
                .ToListAsync();
        }

        public async Task<bool> DeleteAddressByIdAsync(long id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(i => i.Id == id);

            if (address is null)
            {
                return false;
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
