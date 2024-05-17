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
    /// <remarks>
    /// Initializes a new instance of the <see cref="ApplicationUserController"/> class.
    /// </remarks>
    /// <param name="applicationUserService">The application user service.</param>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController(IApplicationUserService applicationUserService) : ControllerBase
    {
        /// <summary>
        /// The application user service.
        /// </summary>
        private readonly IApplicationUserService _applicationUserService = applicationUserService;

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageQuantity">The page quantity.</param>
        /// <returns><![CDATA[A Task<List<ApplicationUserDTO>>.]]></returns>
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<List<ApplicationUserDTO>> GetAll(int pageNumber, int pageQuantity) => await _applicationUserService.GetAll(pageNumber, pageQuantity);


        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <param name="applicationUserFilterDTO">The application user filter DTO.</param>
        /// <returns><![CDATA[A Task<IActionResult>.]]></returns>
        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<IActionResult> Filter([FromQuery] ApplicationUserFilterDTO applicationUserFilterDTO)
        {
            var result = await _applicationUserService.Filter(applicationUserFilterDTO);
            return Ok(new {Message = "Total Users: " + result.ToList().Count, Data = result});
        }

        /// <summary>
        /// Registers a <see cref="UserToken"/>.
        /// </summary>
        /// <param name="applicationUserRegisterDTO">The application user register DTO.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[A Task<ActionResult<UserToken>>.]]></returns>
        [HttpPost("RegisterUser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Post([FromBody] ApplicationUserRegisterDTO applicationUserRegisterDTO, string role)
        {
            var result = await _applicationUserService.Post(applicationUserRegisterDTO, role);
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
        [AllowAnonymous]
        public async Task<IActionResult> Update(ApplicationUserUpdateDTO applicationUserUpdateDTO)
        {
            _ = await _applicationUserService.GetUserName(applicationUserUpdateDTO.UserName) ?? throw new Exception("This user not exits!");
            var applicationUserUpdate = await _applicationUserService.Update(applicationUserUpdateDTO);
            if (applicationUserUpdate is null) return NoContent();
            return Ok(new { email = applicationUserUpdate.Email });
        }

        /// <summary>
        /// Get personal data.
        /// </summary>
        /// <returns><![CDATA[Task<IActionResult>]]></returns>
        [HttpGet("PDF")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPersonalData()
        {
            string pdfPath = await _applicationUserService.ExportToPdf();
            var pdfStream = System.IO.File.OpenRead(pdfPath);
            return File(pdfStream, "application/pdf", $"{DateTime.Now:d}.pdf");
        }
    }
}
