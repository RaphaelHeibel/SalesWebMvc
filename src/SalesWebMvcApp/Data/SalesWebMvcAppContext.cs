
using Microsoft.EntityFrameworkCore;
using SalesWebMvcApp.Models;

namespace SalesWebMvcApp.Data
{
    public class SalesWebMvcAppContext : DbContext
    {
 
        protected readonly IConfiguration Configuration;

        public SalesWebMvcAppContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
