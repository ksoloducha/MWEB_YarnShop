using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace YarnShop.WebApp.Models
{
    public class JWToken
    {
        private IConfiguration Configuration;

        public string TokenUrl { get; set; }
        public string SecretKey { get; set; }
        public string TokenString { get; set; }

        public JWToken(IConfiguration configuration)
        {
            Configuration = configuration;
            TokenUrl = "http://localhost:5252";
            SecretKey = "SuperTajneHaslo122333";
            TokenString = GenerateJSONWebToken();
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{SecretKey}"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: $"{TokenUrl}",
                audience: $"{TokenUrl}",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
