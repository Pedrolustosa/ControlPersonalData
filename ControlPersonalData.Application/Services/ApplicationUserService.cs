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
        /// Initializes a new instance of the <see cref="ApplicationUserService"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <param name="applicationUserRepository">The application user repository.</param>
        /// <param name="mapper">The mapper.</param>
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
        public async Task<List<ApplicationUserDTO>> GetAll(int pageNumber, int pageQuantity)
        {
            var applicationUser = await _userRepository.GetAll(pageNumber, pageQuantity);
            return _mapper.Map<List<ApplicationUserDTO>>(applicationUser);
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
        /// Gets the user name.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <returns><![CDATA[A Task<ApplicationUserDTO>.]]></returns>
        public async Task<ApplicationUserDTO> GetUserName(string userName)
        {
            var user = await _userRepository.GetUserName(userName) ?? throw new ArgumentNullException("This user not exits!");
            var applicationUserDTO = _mapper.Map<ApplicationUserDTO>(user);
            return applicationUserDTO;
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
        /// 
        /// </summary>
        /// <param name="applicationUserRegisterDTO">The application user register DTO.</param>
        /// <param name="role">The role.</param>
        /// <exception cref="Exception"></exception>
        /// <returns><![CDATA[A Task<bool>.]]></returns>
        public async Task<bool> Register(ApplicationUserRegisterDTO applicationUserRegisterDTO, string role)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserRegisterDTO);
            var userExist = await _userManager.FindByEmailAsync(applicationUser.Email);
            if (userExist != null) throw new Exception("Email already exists.");
            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(applicationUser, applicationUserRegisterDTO.Password);
                if (!result.Succeeded) throw new Exception("Error!");
                await _userManager.AddToRoleAsync(applicationUser, role);
                return result.Succeeded;
            }
            else
                throw new Exception("Please, choose a role for this user!");
        }

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="applicationUserUpdateDTO">The application user update DTO.</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns><![CDATA[A Task<ApplicationUserDTO>.]]></returns>
        public async Task<ApplicationUserUpdateDTO> UpdateAccount(ApplicationUserUpdateDTO applicationUserUpdateDTO) 
        {
            var user = await _userRepository.GetUserName(applicationUserUpdateDTO.UserName) ?? throw new ArgumentNullException("This user not exits!");
            applicationUserUpdateDTO.Id = user.Id;
            _mapper.Map(applicationUserUpdateDTO, user);
            if (applicationUserUpdateDTO.Password != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, applicationUserUpdateDTO.Password);
            } 
            await _userManager.UpdateAsync(user);
            var userRetorno = await _userRepository.GetUserName(user.UserName);
            return _mapper.Map<ApplicationUserUpdateDTO>(userRetorno);
        }
    }
}
