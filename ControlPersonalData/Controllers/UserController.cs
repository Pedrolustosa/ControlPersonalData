using Microsoft.AspNetCore.Mvc;
using ControlPersonalData.API.Models;
using Microsoft.AspNetCore.Authorization;
using ControlPersonalData.Application.DTOs;
using ControlPersonalData.Application.Interfaces;

#nullable disable
namespace ControlPersonalData.Controllers
{
    /// <summary>
    /// The user controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The application user service.
        /// </summary>
        private readonly IApplicationUserService _applicationUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="applicationUserService">The application user service.</param>
        public UserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUserFilterDTO>>.]]></returns>
        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<ApplicationUserFilterDTO>> GetAll()
        {
            var result = await _applicationUserService.GetAll();
            return result;
        }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="cPF">The c PF.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="age">The age.</param>
        /// <param name="motherName">The mother name.</param>
        /// <param name="status">If true, status.</param>
        /// <returns><![CDATA[A Task<List<ApplicationUserFilterDTO>>.]]></returns>
        [HttpGet("GetFilter")]
        public async Task<IEnumerable<ApplicationUserFilterDTO>> GetFilter(string email, string name, string phoneNumber, 
                                                                           string cPF, string birthDate, string age, 
                                                                           string motherName, bool status)
        {
            var result = await _applicationUserService.GetFilter(email, name, phoneNumber, cPF, birthDate, age, motherName, status);
            return result;
        }

        /// <summary>
        /// Registers a <see cref="UserToken"/>.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[A Task<ActionResult<UserToken>>.]]></returns>
        [HttpPost("Register")]
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
