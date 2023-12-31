﻿namespace ControlPersonalData.Domain.Account
{
    /// <summary>
    /// The authenticate interface.
    /// </summary>
    public interface IAuthenticateService
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        Task<bool> Authenticate(string email, string password);

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A string.</returns>
        public string GenerateToken(string email);

        /// <summary>
        /// Logouts a <see cref="Task"/>.
        /// </summary>
        /// <returns>A Task.</returns>
        Task Logout();
    }
}
