using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HarvestHub.JWT
{
    public class JwtUtility
    {
        public static bool ValidateToken(string jwtToken, out ClaimsPrincipal principal)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("verysecretkeyverysecretkey")),
                ValidateIssuer = true,
                ValidIssuer = "veryverysecretveryverysecret",
                ValidateAudience = true,
                ValidAudience = "bigsecretbigsecretbigsecret",
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                principal = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out var validatedToken);
                return true;
            }
            catch
            {
                principal = null;
                return false;
            }
        }

        public static List<string> GetUserRoles(ClaimsPrincipal principal)
        {
            var roles = principal.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
            return roles;
        }

        public static string GetUserUsername(ClaimsPrincipal principal)
        {
            string username = principal.FindAll(ClaimTypes.Email).Select(u => u.Value).FirstOrDefault().ToString();
            return username;
        }
    }
}
