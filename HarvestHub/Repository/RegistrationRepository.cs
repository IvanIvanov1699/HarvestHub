using HarvestHub.DTOs;
using HarvestHub.Entities;
using HarvestHub.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HarvestHub.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegistrationRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDTO dto)
        {
            var newUser = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("User").GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Customer"));
                }

                await _userManager.AddToRoleAsync(newUser, "Customer");
            }

            return result;
        }
    }
}
