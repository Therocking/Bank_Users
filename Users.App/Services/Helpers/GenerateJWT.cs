using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Users.App.Interfaces;

namespace Users.App.Services.Helpers
{
    public class GenerateJWT: IGenerateJWT
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

            var tokenHandle = new JwtSecurityTokenHandler();
            var byteKey = Encoding.UTF8.GetBytes(key!);
            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, email),
            new Claim("Scope", "Client")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(byteKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandle.CreateToken(tokenDes);
            return tokenHandle.WriteToken(token);
        }
    }
}
