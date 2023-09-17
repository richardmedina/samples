using AspNetMvc.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvc.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<SalesLeadEntity> SalesLead { get; set; }
    }
}
