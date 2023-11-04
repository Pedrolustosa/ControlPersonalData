using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Domain.Interfaces;
using ControlPersonalData.Infra.Data.Service;
using ControlPersonalData.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using ControlPersonalData.Infra.Data.Repository;
using ControlPersonalData.Application.Interfaces;
using ControlPersonalData.Application.Mappings;

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
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            return services;
        }
    }
}
