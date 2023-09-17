using Microsoft.AspNetCore.Mvc;
using sample_platform_net_7._0_aspnet_webapi.Models;
using sample_platform_net_7._0_aspnet_webapi.Services;

namespace sample_platform_net_7._0_aspnet_webapi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(LoginUser loginUser)
        {
            var result = await _authService.RegisterUserAsync(loginUser);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            bool isLoginDetailValid = await _authService.LoginUserAsync(loginUser);

            return isLoginDetailValid 
                ? Ok(await _authService.GenerateToken(loginUser))
                : BadRequest();
        }
    }
}
