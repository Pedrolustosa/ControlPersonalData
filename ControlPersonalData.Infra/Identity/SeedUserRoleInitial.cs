using Microsoft.AspNetCore.Identity;
using ControlPersonalData.Domain.Account;

namespace ControlPersonalData.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new()
                {
                    Name = "User",
                    NormalizedName = "USER"
                };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@localhost.com").Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "user@localhost.com",
                    Email = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "User@2023").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (_userManager.FindByEmailAsync("admin@localhost.com").Result == null)
            {
                ApplicationUser admin = new()
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(admin, "Admin@2023").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(admin, "admin").Wait();
            }
        }
    }
}
