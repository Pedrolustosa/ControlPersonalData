using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ControlPersonalData.Domain.Account;
using Microsoft.Extensions.Configuration;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Domain.Interfaces;

#nullable disable
namespace ControlPersonalData.Infra.Data.Identity
{
    /// <summary>
    /// The authenticate service.
    /// </summary>
    public class AuthenticateService : IAuthenticateService
    {

        /// <summary>
        /// sign in manager.
        /// </summary>
        private readonly SignInManager<ApplicationUser> _signInManager;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IApplicationUserRepository _userRepository;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateService"/> class.
        /// </summary>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="configuration">The configuration.</param>
        public AuthenticateService(SignInManager<ApplicationUser> signInManager,
                                   IApplicationUserRepository userRepository,
                                   IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="Exception"></exception>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> Authenticate(string userName, string password)
        {
            var statusUser = _userRepository.GetStatusUser(userName);
            if(statusUser)
            {
                var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
                return result.Succeeded;
            }
            throw new Exception("USer Inactive!");
        }

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>A string.</returns>
        public string GenerateToken(string userName)
        {
            var claims = new[]
            {
                new Claim("email", userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expirations = DateTime.UtcNow.AddMinutes(7);

            JwtSecurityToken token = new
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expirations,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Logouts a <see cref="Task"/>.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task Logout() => await _signInManager.SignOutAsync();
    }
}
