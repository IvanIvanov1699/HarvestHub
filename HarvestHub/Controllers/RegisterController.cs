using HarvestHub.Context;
using HarvestHub.DTOs;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;


namespace HarvestHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegisterController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterDTO dto)
        {
            var result = await _registrationRepository.CreateUserAsync(dto);

            if (result.Succeeded)
            {
                return Ok("Successful Registration!");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
