using ControlPersonalData.Application.DTOs;

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
        Task<IEnumerable<ApplicationUserFilterDTO>> GetAll();

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        Task<ApplicationUserDTO> GetById(int id);

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
        /// Register a user
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> Register(ApplicationUserDTO register, string role);
    }
}
