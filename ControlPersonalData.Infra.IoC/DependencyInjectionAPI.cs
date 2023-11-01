using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ControlPersonalData.Domain.Account;
using Microsoft.Extensions.Configuration;
using ControlPersonalData.Infra.Data.Context;
using ControlPersonalData.Infra.Data.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ControlPersonalData.Infra.IoC
{
    /// <summary>
    /// The dependency injection API.
    /// </summary>
    public static class DependencyInjectionAPI
    {
        /// <summary>
        /// Add infrastructure API.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            
            services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddDefaultTokenProviders();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            return services;
        }
    }
}
