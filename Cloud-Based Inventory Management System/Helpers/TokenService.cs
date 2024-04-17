using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cloud_Based_Inventory_Management_System.Helpers
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(List<Claim> claims)
        {
            // Read JWT configuration from appsettings.json
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var issuer = jwtSettings["Issuer"];
            var secretKey = jwtSettings["SecretKey"];

            // Create symmetric security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // Create signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create JWT token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(jwtSettings["ExpirationHours"])),
                signingCredentials: creds
            );



            // Write JWT token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
