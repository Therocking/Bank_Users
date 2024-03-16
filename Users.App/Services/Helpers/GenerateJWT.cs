using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Users.App.Interfaces;

namespace Users.App.Services.Helpers
{
    public class GenerateJWT : IGenerateJWT
    {
        private readonly IConfiguration _config;

        public GenerateJWT(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(string email)
        {
            var jwtSettingsSection = _config.GetSection("JwtSettings");
            var key = jwtSettingsSection["Key"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(key);
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var createToken = tokenHandler.CreateToken(tokenDes);
            var token = tokenHandler.WriteToken(createToken);
            return token;
        }
    }
}
