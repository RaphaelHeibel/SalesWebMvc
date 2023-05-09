using Microsoft.EntityFrameworkCore;
using src.Models;

namespace SalesWebMvcApp.Data
{
    public class SalesContext : DbContext
    {
     
        public SalesContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected readonly IConfiguration Configuration;

         protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("SalesContext");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));  
        }

        public DbSet<Department> Department { get; set; } = default!;
    }
}
