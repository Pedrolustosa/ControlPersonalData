using ControlPersonalData.Application.DTOs;

namespace ControlPersonalData.Application.Interfaces
{
    /// <summary>
    /// The authenticate interface.
    /// </summary>
    public interface IApplicationUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> Authenticate(string email, string password);

        /// <summary>
        /// Registers user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> RegisterUser(ApplicationUserDTO register, string role);

        /// <summary>
        /// Logouts a <see cref="Task"/>.
        /// </summary>
        /// <returns>A Task.</returns>
        Task Logout();

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
    }
}
