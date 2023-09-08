using HarvestHub.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HarvestHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] DTOs.LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if (user == null)
            {
                return NotFound("User Not Found!");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!signInResult.Succeeded)
            {
                return Unauthorized("Wrong credentials!");
            }

            var token = GenerateJwtTokenAsync(user);

            return Ok(new { Token = token });
        }

        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, roles?.FirstOrDefault()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}