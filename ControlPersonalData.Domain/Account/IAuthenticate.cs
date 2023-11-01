using ControlPersonalData.Models.Entities;

namespace ControlPersonalData.Domain.Account
{
    /// <summary>
    /// The authenticate interface.
    /// </summary>
    public interface IAuthenticate
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
        Task<bool> RegisterUser(Register register, string role);

        /// <summary>
        /// Logouts a <see cref="Task"/>.
        /// </summary>
        /// <returns>A Task.</returns>
        Task Logout();
    }
}
