
using Microsoft.EntityFrameworkCore;
using SalesWebMvcApp.Data;

namespace src
{
    public class Startup : IStartup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        IConfiguration Configuration { get; }

        IConfiguration IStartup.Configuration => throw new NotImplementedException();


        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration.GetConnectionString("BancoTeste");

            services.AddDbContext<SalesContext>(options =>
                options.UseMySql(connectionString ?? throw new InvalidOperationException("Connection string 'SalesContext' not found."), ServerVersion.AutoDetect(connectionString)));


            services.AddControllersWithViews();

            services.AddDbContext<SalesContext>();
        }


        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return WebAppBuilder;
        }
    }
}

