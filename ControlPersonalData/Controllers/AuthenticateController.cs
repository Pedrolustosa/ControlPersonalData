using Microsoft.AspNetCore.Mvc;
using ControlPersonalData.API.Models;
using ControlPersonalData.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using ControlPersonalData.Domain.Entities;

namespace ControlPersonalData.API.Controllers
{
    /// <summary>
    /// The authenticate controller.
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        /// <summary>
        /// The authentication.
        /// </summary>
        private readonly IAuthenticateService _authentication;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateController"/> class.
        /// </summary>
        /// <param name="authentication">The authentication.</param>
        public AuthenticateController(IAuthenticateService authentication)
        {
            _authentication = authentication;
        }

        /// <summary>
        /// Authenticates a <see cref="UserToken"/>.
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns><![CDATA[A Task<ActionResult<UserToken>>.]]></returns>
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Authenticate([FromBody] Login login)
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
    }
}
