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
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
            _configuration  = configuration;
        }

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

        private UserToken GenerateToken(Login login)
        {
            var claims = new[]
            {
                new Claim("email", login.Email),
                new Claim("newValue", "newValue"),
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
