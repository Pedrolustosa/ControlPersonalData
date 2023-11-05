﻿using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="name">The name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="cPF">The c PF.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="age">The age.</param>
        /// <param name="motherName">The mother name.</param>
        /// <param name="status">If true, status.</param>
        /// <returns><![CDATA[A Task<List<ApplicationUser>>.]]></returns>
        public async Task<IEnumerable<ApplicationUser>> GetFilter(string email, string name, string phoneNumber, 
                                                                  string cPF, string birthDate, string age,
                                                                  string motherName, bool status)
        {
            var filterUsers = await _context.Users.Where(u => u.Email == email ||
                                                         u.Name == name ||
                                                         u.PhoneNumber == phoneNumber || 
                                                         u.CPF == cPF || 
                                                         u.BirthDate.ToString() == birthDate || 
                                                         u.Age == age || 
                                                         u.MotherName == motherName || 
                                                         u.Status.Equals(status)).ToListAsync();
            return filterUsers;
        }
    }
}
