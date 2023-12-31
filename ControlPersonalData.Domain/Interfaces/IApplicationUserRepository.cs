﻿using ControlPersonalData.Domain.Entities;

namespace ControlPersonalData.Domain.Interfaces
{
    /// <summary>
    /// The application repository interface.
    /// </summary>
    public interface IApplicationUserRepository
    {
        /// <summary>
        /// Gets the data PDF.
        /// </summary>
        /// <returns>A string.</returns>
        string GetDataPDF();

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        Task<List<ApplicationUser>> GetAll(int pageNumber, int pageQuantity);

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        Task<ApplicationUser> GetById(string id);

        /// <summary>
        /// Gets the status user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>A bool.</returns>
        bool GetStatusUser(string userName);

        /// <summary>
        /// Get the by email.
        /// </summary>
        /// <param name="userName">The email.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        Task<ApplicationUser> GetUserName(string userName);

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="motherName">The mother name.</param>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        Task<List<ApplicationUser>> GetFilter(string email, string name, string birthDate, string motherName);

        /// <summary>
        /// Exist this CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns>A bool.</returns>
        bool ExistingCPF(string cpf);
    }
}
