using HarvestHub.Context;
using HarvestHub.DTOs;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressDTO dto)
        {
            var newAddress = await _addressRepository.CreateAddressAsync(dto);
            return Ok("Address added successfully!");
        }

        [HttpGet]
        public async Task<ActionResult<List<Address>>> GetAllAddresses()
        {
            var addresses = await _addressRepository.GetAllAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet]
        [Route("{UserName}")]
        public async Task<ActionResult<List<Address>>> GetAddressByUserName([FromRoute] string UserName)
        {
            var addresses = await _addressRepository.GetAddressesByUserNameAsync(UserName);

            if (addresses == null || !addresses.Any())
            {
                return NotFound("Item not found!");
            }
            return Ok(addresses);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAddressById([FromRoute] long id)
        {
            var result = await _addressRepository.DeleteAddressByIdAsync(id);

            if (!result)
            {
                return NotFound("Item not found!");
            }

            return Ok("Item deleted successfully!");
        }
    }
}
