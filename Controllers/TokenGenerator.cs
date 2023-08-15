using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecureAuthPOC.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureAuthPOC.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenGenerator : ControllerBase
    {
        private readonly IConfiguration _config;
        public TokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public string TokenGen(BaseRegister user)
        {

            
            return GenerateToken(user);
        }

        
        private string GenerateToken( BaseRegister user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("email",user.email),
                
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
