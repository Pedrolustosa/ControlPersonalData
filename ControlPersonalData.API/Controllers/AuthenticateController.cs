using Microsoft.AspNetCore.Mvc;
using ControlPersonalData.API.Models;
using Microsoft.AspNetCore.Authorization;
using ControlPersonalData.Domain.Account;
using ControlPersonalData.Domain.Entities;

namespace ControlPersonalData.API.Controllers
{
    /// <summary>
    /// The authenticate controller.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="AuthenticateController"/> class.
    /// </remarks>
    /// <param name="authentication">The authentication.</param>
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController(IAuthenticateService authentication) : ControllerBase
    {
        /// <summary>
        /// The authentication.
        /// </summary>
        private readonly IAuthenticateService _authentication = authentication;

        /// <summary>
        /// Authenticates a <see cref="UserToken"/>.
        /// </summary>
        /// <param name="loginDTO">The login.</param>
        /// <returns><![CDATA[A Task<ActionResult<UserToken>>.]]></returns>
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Authenticate([FromBody] LoginDTO loginDTO)
        {
            var result = await _authentication.Authenticate(loginDTO.UserName, loginDTO.Password);
            if (result)
            {
                var token = _authentication.GenerateToken(loginDTO.UserName);
                return new UserToken { Token = token };
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }
    }
}
