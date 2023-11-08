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
        Task<ApplicationUserDTO> GetById(int id);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="userName">The email.</param>
        /// <returns><![CDATA[A Task<ApplicationUserDTO>.]]></returns>
        Task<ApplicationUserDTO> GetUserName(string userName);

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
        /// <returns><![CDATA[A Task<IEnumerable<ApplicationUserFilterDTO>>.]]></returns>
        Task<IEnumerable<ApplicationUserFilterDTO>> GetFilter(string email, string name, string phoneNumber, 
                                                              string cPF, string birthDate, string age, 
                                                              string motherName, bool status);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationUserRegisterDTO">The application user register DTO.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> Register(ApplicationUserRegisterDTO applicationUserRegisterDTO, string role);

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="applicationUserUpdateDTO">The application user update DTO.</param>
        /// <returns><![CDATA[A Task<ApplicationUserUpdateDTO>.]]></returns>
        Task<ApplicationUserUpdateDTO> UpdateAccount(ApplicationUserUpdateDTO applicationUserUpdateDTO);

        /// <summary>
        /// Export the to pdf.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>A string.</returns>
        string ExportToPdf(DataTable data, string fileName);

        /// <summary>
        /// Gets the personal data.
        /// </summary>
        /// <returns>A DataTable.</returns>
        DataTable GetPersonalData();
    }
}
