using Microsoft.AspNetCore.Identity;

namespace sample_platform_net_7._0_aspnet_webapi.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
