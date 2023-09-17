using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sample_platform_net_7._0_aspnet_webapi.Models.Token;
using sample_platform_net_7._0_aspnet_webapi.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace sample_platform_net_7._0_aspnet_webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(UserCredentials userCredentials)
        {
            if(userCredentials.UserName == "admin" && userCredentials.Password == "admin")
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, MagicConfiguration.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", userCredentials.UserName),
                    new Claim("DisplayName", "Administrator"),
                    new Claim("UserName", userCredentials.UserName),
                    new Claim("Email", $"${userCredentials.UserName}@domain.com")
                };

                var signin = new SigningCredentials(MagicConfiguration.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    MagicConfiguration.Issuer, 
                    MagicConfiguration.Audience, 
                    claims, 
                    expires: DateTime.UtcNow.AddMinutes(3), 
                    signingCredentials: signin
                    );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest();
        }
    }
}
