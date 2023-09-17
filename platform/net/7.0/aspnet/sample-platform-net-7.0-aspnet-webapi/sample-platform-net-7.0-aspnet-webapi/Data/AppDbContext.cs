using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace sample_platform_net_7._0_aspnet_webapi.Data
{
    public class AppDbContext : IdentityDbContext
    {

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
