using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlPersonalData.Infra.Data.EntityConfiguration
{
    /// <summary>
    /// The seed role configuration.
    /// </summary>
    public class SeedRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        /// <summary>
        /// Configure IdenityRole
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }
            );
        }
    }
}
