using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using sample_platform_net_7._0_aspnet_webapi.Data;
using sample_platform_net_7._0_aspnet_webapi.Models;
using sample_platform_net_7._0_aspnet_webapi.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace sample_platform_net_7._0_aspnet_webapi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> LoginUserAsync(LoginUser loginUser)
        {
            var applicationUser = await _userManager.FindByEmailAsync(loginUser.UserName);

            if(applicationUser == null)
            {
                return false;
            }

            var result = await _userManager.CheckPasswordAsync(applicationUser, loginUser.Password);

            return result;
        }

        public async Task<bool> RegisterUserAsync(LoginUser loginUser)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = loginUser.UserName,
                Email = loginUser.UserName
            };

            var result = await _userManager.CreateAsync(applicationUser, loginUser.Password);

            return result.Succeeded;
        }

        public async Task<string> GenerateToken(LoginUser loginUser)
        {
            await Task.CompletedTask;

            var claims = new[] { 
                new Claim(ClaimTypes.Email, loginUser.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var signinCredentials = new SigningCredentials(MagicConfiguration.SymmetricSecurityKey, MagicConfiguration.SecurityAlgorithm);
            var securityToken = new JwtSecurityToken(claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                issuer: MagicConfiguration.Issuer,
                audience: MagicConfiguration.Audience,
                signingCredentials: signinCredentials);


            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
