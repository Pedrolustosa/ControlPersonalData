using ControlPersonalData.Domain.Entities;

namespace ControlPersonalData.Domain.Interfaces
{
    /// <summary>
    /// The application repository interface.
    /// </summary>
    public interface IApplicationUserRepository
    {
        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        Task<IEnumerable<ApplicationUser>> GetAll();
        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        Task<ApplicationUser> GetById(int id);
    }
}
