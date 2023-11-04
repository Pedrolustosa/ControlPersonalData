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
        Task<IEnumerable<ApplicationUserDTO>> GetAll();

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        Task<ApplicationUserDTO> GetById(int id);

        /// <summary>
        /// Registers user.
        /// </summary>
        /// <param name="register">The register.</param>
        /// <param name="role">The role.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> Register(ApplicationUserDTO register, string role);
    }
}
