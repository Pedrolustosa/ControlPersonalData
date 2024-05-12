using Microsoft.EntityFrameworkCore;
using ControlPersonalData.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ControlPersonalData.Infra.Data.Context
{
    /// <summary>
    /// The application db context.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </remarks>
    /// <param name="options">The options.</param>
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        /// <summary>
        /// On model creating.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
