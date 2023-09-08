using HarvestHub.DTOs;
using HarvestHub.Entities;

namespace HarvestHub.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(AddressDTO dto);
        Task<List<Address>> GetAllAddressesAsync();
        Task<List<Address>> GetAddressesByUserNameAsync(string userName);
        Task<bool> DeleteAddressByIdAsync(long id);
    }
}
