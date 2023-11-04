using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Domain.Interfaces;
using ControlPersonalData.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace ControlPersonalData.Infra.Data.Repository
{
    /// <summary>
    /// The application user repository.
    /// </summary>
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
           var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        public async Task<ApplicationUser> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}
