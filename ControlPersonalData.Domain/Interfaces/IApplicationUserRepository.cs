using ControlPersonalData.Domain.Entities;

namespace ControlPersonalData.Domain.Interfaces
{
    /// <summary>
    /// The application user repository interface.
    /// </summary>
    public interface IApplicationUserRepository
    {
        /// <summary>
        /// Get data PDF.
        /// </summary>
        /// <returns><![CDATA[Task<List<ApplicationUser>>]]></returns>
        Task<List<ApplicationUser>> GetDataPDF();

        /// <summary>
        /// Get the all.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageQuantity">The page quantity.</param>
        /// <returns><![CDATA[Task<List<ApplicationUser>>]]></returns>
        Task<List<ApplicationUser>> GetAll(int pageNumber, int pageQuantity);

        /// <summary>
        /// Get by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[Task<ApplicationUser>]]></returns>
        Task<ApplicationUser> GetById(string id);

        /// <summary>
        /// Get status user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        Task<bool> GetStatusUser(string userName);

        /// <summary>
        /// Get user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns><![CDATA[Task<ApplicationUser>]]></returns>
        Task<ApplicationUser> GetUserName(string userName);

        /// <summary>
        /// Get the filter.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="motherName">The mother name.</param>
        /// <returns><![CDATA[Task<List<ApplicationUser>>]]></returns>
        Task<List<ApplicationUser>> GetFilter(string email, string name, string birthDate, string motherName);

        /// <summary>
        /// Existing CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        Task<bool> ExistingCPF(string cpf);
    }
}
