using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Application.DTOs;
using ControlPersonalData.Domain.Interfaces;
using ControlPersonalData.Application.Interfaces;

#nullable disable
namespace ControlPersonalData.Infra.Data.Service
{
    /// <summary>
    /// The authenticate service.
    /// </summary>
    public class ApplicationUserService : IApplicationUserService
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// The role manager.
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IApplicationUserRepository _userRepository;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        public ApplicationUserService(UserManager<ApplicationUser> userManager,
                                   RoleManager<IdentityRole> roleManager,
                                   IApplicationUserRepository applicationUserRepository,
                                   IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRepository = applicationUserRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<List<ApplicationUserDTO>>.]]></returns>
        public async Task<IEnumerable<ApplicationUserFilterDTO>> GetAll()
        {
            var applicationUser = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<ApplicationUserFilterDTO>>(applicationUser);
        }

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ApplicationUserDTO>.]]></returns>
        public async Task<ApplicationUserDTO> GetById(int id)
        {
            var applicationUser = await _userRepository.GetById(id);
            return _mapper.Map<ApplicationUserDTO>(applicationUser);
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
        /// <returns><![CDATA[A Task<List<ApplicationUserFilterDTO>>.]]></returns>
        public async Task<IEnumerable<ApplicationUserFilterDTO>> GetFilter(string email, string name, string phoneNumber, string cPF, string birthDate, string age, string motherName, bool status)
        {
            var applicationUser = await _userRepository.GetFilter(email, name, phoneNumber, cPF, birthDate, age, motherName, status);
            return _mapper.Map<IEnumerable<ApplicationUserFilterDTO>>(applicationUser);
        }

        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="applicationUser">The application user.</param>
        /// <param name="role">The role.</param>
        /// <exception cref="Exception"></exception>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> Register(ApplicationUserDTO applicationUser, string role)
        {
            var register = _mapper.Map<ApplicationUser>(applicationUser);
            var userExist = await _userManager.FindByEmailAsync(register.Email);
            if (userExist != null)
                throw new Exception("Email already exists.");

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(register, applicationUser.Password);
                if (!result.Succeeded)
                    throw new Exception("Error!");

                await _userManager.AddToRoleAsync(register, role);
                return result.Succeeded;
            }
            else
                throw new Exception("Please, choose a role for this user!");
        }
    }
}
