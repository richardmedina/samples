using sample_platform_net_7._0_aspnet_webapi.Models;

namespace sample_platform_net_7._0_aspnet_webapi.Services
{
    public interface IAuthService
    {
        Task<bool> LoginUserAsync(LoginUser loginUser);
        Task<bool> RegisterUserAsync(LoginUser loginUser);
        Task<string> GenerateToken(LoginUser loginUser);
    }
}