using Microsoft.AspNetCore.Identity;
using ControlPersonalData.Domain.Account;
using ControlPersonalData.Models.Entities;
using Azure.Core;

namespace ControlPersonalData.Infra.Data.Identity
{
    /// <summary>
    /// The authenticate service.
    /// </summary>
    public class AuthenticateService : IAuthenticate
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;
        /// <summary>
        /// sign in manager.
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// The role manager.
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public AuthenticateService(UserManager<ApplicationUser> userManager, 
                                   SignInManager<ApplicationUser> signInManager, 
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Logins
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        /// <summary>
        /// Registers user.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="role">The role.</param>
        /// <exception cref="Exception"></exception>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> RegisterUser(Register register, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(register.Email);
            if (userExist != null)
                throw new Exception("Email already exists.");

            ApplicationUser applicationUser = NewUser(register);

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(applicationUser, register.Password);
                if (!result.Succeeded)
                    throw new Exception("Error!");

                await _userManager.AddToRoleAsync(applicationUser, role);
                return result.Succeeded;
            }
            else
                throw new Exception("Please, choose a role for this user!");
        }

        /// <summary>
        /// Logouts a <see cref="Task"/>.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task Logout() => await _signInManager.SignOutAsync();

        /// <summary>
        /// News the user.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <returns>An ApplicationUser.</returns>
        private static ApplicationUser NewUser(Register register)
        {
            return new ApplicationUser
            {
                Email = register.Email,
                UserName = register.Email,
                CPF = register.CPF,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
        }
    }
}
