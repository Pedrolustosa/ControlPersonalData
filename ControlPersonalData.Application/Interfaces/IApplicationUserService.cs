using ControlPersonalData.Application.DTOs;
using System.Data;

namespace ControlPersonalData.Application.Interfaces
{
    /// <summary>
    /// The application user service interface.
    /// </summary>
    public interface IApplicationUserService
    {
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        Task<List<ApplicationUserDTO>> GetAll(int pageNumber, int pageQuantity);

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        Task<ApplicationUserDTO> GetById(string id);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="userName">The email.</param>
        /// <returns><![CDATA[A Task<ApplicationUserDTO>.]]></returns>
        Task<ApplicationUserDTO> GetUserName(string userName);

        /// <summary>
        /// Filters and return a task of a list of applicationuserfilterdtos.
        /// </summary>
        /// <param name="applicationUserFilterDTO">The application user filter DTO.</param>
        /// <returns><![CDATA[Task<IEnumerable<ApplicationUserFilterDTO>>]]></returns>
        Task<IEnumerable<ApplicationUserFilterDTO>> Filter(ApplicationUserFilterDTO applicationUserFilterDTO);

        /// <summary>
        /// Post and return a task of type bool.
        /// </summary>
        /// <param name="applicationUserRegisterDTO">The application user register DTO.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        Task<bool> Post(ApplicationUserRegisterDTO applicationUserRegisterDTO, string role);

        /// <summary>
        /// Update and return a task of type applicationuserupdatedto.
        /// </summary>
        /// <param name="applicationUserUpdateDTO">The application user update DTO.</param>
        /// <returns><![CDATA[Task<ApplicationUserUpdateDTO>]]></returns>
        Task<ApplicationUserUpdateDTO> Update(ApplicationUserUpdateDTO applicationUserUpdateDTO);

        /// <summary>
        /// Export converts to pdf.
        /// </summary>
        /// <returns><![CDATA[Task<string>]]></returns>
        Task<string> ExportToPdf();

        /// <summary>
        /// Gets the personal data.
        /// </summary>
        /// <returns>A DataTable.</returns>
        Task<DataTable> GetPersonalData();

        /// <summary>
        /// Validate CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        Task<bool> ValidateCPF(string cpf);

        /// <summary>
        /// Existing CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        Task<bool> ExistingCPF(string cpf);
    }
}
