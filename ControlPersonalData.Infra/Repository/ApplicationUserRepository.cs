using Microsoft.EntityFrameworkCore;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Domain.Interfaces;
using ControlPersonalData.Infra.Data.Context;

#nullable disable
namespace ControlPersonalData.Infra.Data.Repository
{
    /// <summary>
    /// The application user repository.
    /// </summary>
    /// <param name="context">The context.</param>
    public class ApplicationUserRepository(ApplicationDbContext context) : IApplicationUserRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly ApplicationDbContext _context = context;

        /// <summary>
        /// Get the all.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageQuantity">The page quantity.</param>
        /// <returns><![CDATA[Task<List<ApplicationUser>>]]></returns>
        public async Task<List<ApplicationUser>> GetAll(int pageNumber, int pageQuantity) => await _context.Users.Skip((pageNumber -1) * pageQuantity)
                                                                                                                 .Take(pageQuantity).ToListAsync();

        /// <summary>
        /// Get user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns><![CDATA[Task<ApplicationUser>]]></returns>
        public async Task<ApplicationUser> GetUserName(string userName) => await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName);

        /// <summary>
        /// Get status user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> GetStatusUser(string userName) => await _context.Users.AnyAsync(x => x.UserName == userName && x.Status);

        /// <summary>
        /// Get by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[Task<ApplicationUser>]]></returns>
        public async Task<ApplicationUser> GetById(string id) => await _context.Users.FindAsync(id);

        /// <summary>
        /// Get the filter.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="motherName">The mother name.</param>
        /// <returns><![CDATA[Task<List<ApplicationUser>>]]></returns>
        public async Task<List<ApplicationUser>> GetFilter(string email, string name, string birthDate, string motherName)
        {
            return await _context.Users.Where(u => u.Email == email ||
                                                   u.Name == name ||
                                                   u.BirthDate.ToString() == birthDate ||
                                                   u.MotherName == motherName).ToListAsync();
        }

        /// <summary>
        /// Get data PDF.
        /// </summary>
        /// <returns><![CDATA[Task<List<ApplicationUser>>]]></returns>
        public async Task<List<ApplicationUser>> GetDataPDF()
        {
            return await _context.Users
                   .Select(user => new ApplicationUser (
                        user.Email,
                        user.UserName,
                        user.PhoneNumber,
                        user.Name,
                        user.CPF,
                        user.BirthDate,
                        user.MotherName,
                        true
                    )).ToListAsync();
        }

        /// <summary>
        /// Existing CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public Task<bool> ExistingCPF(string cpf) => _context.Users.AnyAsync(u => u.CPF == cpf);
    }
}
