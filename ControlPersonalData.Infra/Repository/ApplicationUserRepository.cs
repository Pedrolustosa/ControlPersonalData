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
        public ApplicationUserRepository(ApplicationDbContext context) => _context = context;

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        public async Task<List<ApplicationUser>> GetAll(int pageNumber, int pageQuantity) => await _context.Users.Skip((pageNumber -1) * pageQuantity)
                                                                                                                 .Take(pageQuantity).ToListAsync();

        /// <summary>
        /// Gets the user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        public async Task<ApplicationUser> GetUserName(string userName) => await _context.Users.SingleOrDefaultAsync(x => x.UserName == userName);

        /// <summary>
        /// Gets the status user.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns>A bool.</returns>
        public bool GetStatusUser(string userName) => _context.Users.Any(x => x.UserName == userName && x.Status == true);

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUser>.]]></returns>
        public async Task<ApplicationUser> GetById(string id) => await _context.Users.FindAsync(id);

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="cPF">The c PF.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="motherName">The mother name.</param>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        public async Task<List<ApplicationUser>> GetFilter(string email, string name, string phoneNumber, 
                                                           string cPF, string birthDate, string motherName)
        {
            return await _context.Users.Where(u => u.Email == email ||
                                                   u.Name == name ||
                                                   u.PhoneNumber == phoneNumber || 
                                                   u.CPF == cPF || 
                                                   u.BirthDate.ToString() == birthDate ||
                                                   u.MotherName == motherName).ToListAsync();
        }

        /// <summary>
        /// Gets the data PDF.
        /// </summary>
        /// <returns>A string.</returns>
        public string GetDataPDF() => @"SELECT Email, Name, CPF, Age, MotherName, PhoneNumber, Status FROM AspNetUsers";
        

        /// <summary>
        /// Exist this CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns>A bool.</returns>
        public bool ExistingCPF(string cpf) => _context.Users.Any(u => u.CPF == cpf);
        
    }
}
