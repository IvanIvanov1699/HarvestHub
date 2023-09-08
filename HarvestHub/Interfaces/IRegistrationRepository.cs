using HarvestHub.DTOs;
using Microsoft.AspNetCore.Identity;

namespace HarvestHub.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<IdentityResult> CreateUserAsync(RegisterDTO dto);
    }
}
