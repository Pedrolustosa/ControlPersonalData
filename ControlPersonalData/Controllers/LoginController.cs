using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ControlPersonalData.Models.User;
using System.IdentityModel.Tokens.Jwt;
using ControlPersonalData.Domain.Account;
using Microsoft.AspNetCore.Authorization;

namespace ControlPersonalData.Controllers
{
    /// <summary>
    /// The login controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// The authentication.
        /// </summary>
        private readonly IAuthenticate _authentication;
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="authentication">The authentication.</param>
        /// <param name="configuration">The configuration.</param>
        public LoginController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
            _configuration  = configuration;
        }

        /// <summary>
        /// Logins a <see cref="UserToken"/>.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns><![CDATA[A Task<ActionResult<UserToken>>.]]></returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody] Login login)
        {
            var result = await _authentication.Authenticate(login.Email, login.Password);
            if (result)
            {
                return GenerateToken(login);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Registers a <see cref="ActionResult"/>.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
        [HttpPost("Register")]
        [Authorize]
        public async Task<ActionResult> Register([FromBody] Login login)
        {
            var result = await _authentication.RegisterUser(login.Email, login.Password);
            if (result)
                return Ok($"User {login.Email} was created with success!");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns>An UserToken.</returns>
        private UserToken GenerateToken(Login login)
        {
            var claims = new[]
            {
                new Claim("email", login.Email),
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

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expirations
            };
        }
    }
}
