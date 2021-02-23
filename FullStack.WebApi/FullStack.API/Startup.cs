using FullStack.API.Helpers;
using FullStack.API.Services;
using FullStack.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddDbContext<FullStackDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WebApi")));
            services.AddScoped<IFullStackRepository, FullStackRepository>();

            // configure strongly typed settings objects
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdverts_Service, AdvertService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IProvinceService, ProvinceService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                 .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
