using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace sample_platform_net_7._0_aspnet_webapi.Static
{
    public static class MagicConfiguration
    {
        public static string Key = "TestSymmetricSecurityKey";

        public static SymmetricSecurityKey SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        public static string Issuer = "JWTAuthenticationServer";
        public static string Audience = "JWTServicePostManClient";
        public static string Subject = "JWTServiceAccessToken";

        public static string SecurityAlgorithm = SecurityAlgorithms.HmacSha512Signature;
    }
}
