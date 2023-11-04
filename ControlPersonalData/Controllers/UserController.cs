using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Application.DTOs;
using ControlPersonalData.Infra.Data.Identity;
using ControlPersonalData.Domain.Account;
using ControlPersonalData.Application.Interfaces;

#nullable disable
namespace ControlPersonalData.Controllers
{
    /// <summary>
    /// The user controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The authentication.
        /// </summary>
        private readonly IAuthenticateService _authentication;

        /// <summary>
        /// The authentication.
        /// </summary>
        private readonly IApplicationUserService _applicationUserService;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="authentication">The authentication.</param>
        /// <param name="applicationUserService">The application user service.</param>
        /// <param name="configuration">The configuration.</param>
        public UserController(IAuthenticateService authentication, IApplicationUserService applicationUserService, IConfiguration configuration)
        {
            _authentication = authentication;
            _configuration  = configuration;
            _applicationUserService = applicationUserService;
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
                var token = _authentication.GenerateToken(login.Email);
                return new UserToken
                {
                    Token = token,
                };
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
        /// <param name="register">The register.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
        [HttpPost("Register")]
        [Authorize]
        public async Task<ActionResult<UserToken>> Register([FromBody] ApplicationUserDTO register, string role)
        {
            var result = await _applicationUserService.Register(register, role);
            if (result)
                return Ok($"User {register.Email} was created with success!");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }
    }
}
