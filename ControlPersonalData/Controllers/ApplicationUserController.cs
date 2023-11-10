using System.Data;
using Microsoft.AspNetCore.Mvc;
using ControlPersonalData.API.Models;
using Microsoft.AspNetCore.Authorization;
using ControlPersonalData.Application.DTOs;
using ControlPersonalData.Application.Interfaces;

#nullable disable
namespace ControlPersonalData.Controllers
{
    /// <summary>
    /// The application user controller.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        /// <summary>
        /// The application user service.
        /// </summary>
        private readonly IApplicationUserService _applicationUserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserController"/> class.
        /// </summary>
        /// <param name="applicationUserService">The application user service.</param>
        public ApplicationUserController(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUserFilterDTO>>.]]></returns>
        [HttpGet("GetAllUsers")]
        public async Task<List<ApplicationUserDTO>> GetAll(int pageNumber, int pageQuantity)
        {
            var result = await _applicationUserService.GetAll(pageNumber, pageQuantity);
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
        [AllowAnonymous]
        public async Task<IActionResult> GetFilter([FromQuery] ApplicationUserFilterDTO applicationUserFilterDTO)
        {
            var result = await _applicationUserService.GetFilter(applicationUserFilterDTO.Email, 
                applicationUserFilterDTO.Name, 
                applicationUserFilterDTO.PhoneNumber,
                applicationUserFilterDTO.CPF,
                applicationUserFilterDTO.BirthDate.ToString(),
                applicationUserFilterDTO.Age,
                applicationUserFilterDTO.MotherName,
                applicationUserFilterDTO.Status);
            return Ok(new {Message = "Total Users: " + result.ToList().Count, Data = result});
        }

        /// <summary>
        /// Registers a <see cref="UserToken"/>.
        /// </summary>
        /// <param name="applicationUserRegisterDTO">The application user register DTO.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[A Task<ActionResult<UserToken>>.]]></returns>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Register([FromBody] ApplicationUserRegisterDTO applicationUserRegisterDTO, string role)
        {
            var result = await _applicationUserService.Register(applicationUserRegisterDTO, role);
            if (result)
                return Ok($"User {applicationUserRegisterDTO.Email} was created with success!");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="applicationUserUpdateDTO">The application user update DTO.</param>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(ApplicationUserUpdateDTO applicationUserUpdateDTO)
        {
            _ = await _applicationUserService.GetUserName(applicationUserUpdateDTO.UserName) ?? throw new ArgumentNullException("This user not exits!");
            var applicationUserUpdate = await _applicationUserService.UpdateAccount(applicationUserUpdateDTO);
            if (applicationUserUpdate is null) return NoContent();
            return Ok(new { email = applicationUserUpdate.Email });
        }

        /// <summary>
        /// Gets the personal data.
        /// </summary>
        /// <returns>An ActionResult.</returns>
        [HttpGet("PDF")]
        public IActionResult GetPersonalData()
        {
            DataTable data = _applicationUserService.GetPersonalData();
            string pdfPath = _applicationUserService.ExportToPdf(data, "ListUsers-" + DateTime.Now.ToString("dd-MM-yyyy"));
            var pdfStream = System.IO.File.OpenRead(pdfPath);
            return File(pdfStream, "application/pdf", "ListUsers-" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf");
        }
    }
}
