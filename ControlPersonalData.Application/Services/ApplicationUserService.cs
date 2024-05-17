using AutoMapper;
using System.Data;
using iText.Layout;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout.Element;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Identity;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Application.DTOs;
using ControlPersonalData.Domain.Interfaces;
using ControlPersonalData.Application.Interfaces;

namespace ControlPersonalData.Infra.Data.Service
{
    /// <summary>
    /// The application user service.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    /// <param name="roleManager">The role manager.</param>
    /// <param name="applicationUserRepository">The application user repository.</param>
    /// <param name="mapper">The mapper.</param>
    public class ApplicationUserService(UserManager<ApplicationUser> userManager,
                                        RoleManager<IdentityRole> roleManager,
                                        IApplicationUserRepository applicationUserRepository,
                                        IMapper mapper) : IApplicationUserService
    {
        /// <summary>
        /// The user manager.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        /// <summary>
        /// The role manager.
        /// </summary>
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        /// <summary>
        /// The user repository.
        /// </summary>
        private readonly IApplicationUserRepository _userRepository = applicationUserRepository;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper = mapper;

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
        public async Task<ApplicationUserDTO> GetById(string id)
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
            var user = await _userRepository.GetUserName(userName) ?? throw new Exception("This user not exits!");
            return _mapper.Map<ApplicationUserDTO>(user);
        }

        /// <summary>
        /// Filters and return a task of a list of applicationuserfilterdtos.
        /// </summary>
        /// <param name="applicationUserFilterDTO">The application user filter DTO.</param>
        /// <returns><![CDATA[Task<IEnumerable<ApplicationUserFilterDTO>>]]></returns>
        public async Task<IEnumerable<ApplicationUserFilterDTO>> Filter(ApplicationUserFilterDTO applicationUserFilterDTO)
        {
            var applicationUser = await _userRepository.GetFilter(applicationUserFilterDTO.Email, 
                                                                  applicationUserFilterDTO.Name, 
                                                                  nameof(applicationUserFilterDTO.BirthDate), 
                                                                  applicationUserFilterDTO.MotherName);
            return _mapper.Map<IEnumerable<ApplicationUserFilterDTO>>(applicationUser);
        }

        /// <summary>
        /// Post and return a task of type bool.
        /// </summary>
        /// <param name="applicationUserRegisterDTO">The application user register DTO.</param>
        /// <param name="role">The role.</param>
        /// <exception cref="Exception"></exception>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> Post(ApplicationUserRegisterDTO applicationUserRegisterDTO, string role)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(applicationUserRegisterDTO);
            var isCPF = await ValidateCPF(applicationUser.CPF);
            var existingCPF = await ExistingCPF(applicationUser.CPF);
            if (isCPF && !existingCPF)
            {
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
            else
            {
                throw new Exception("CPF or Age Invalid");
            }
        }

        /// <summary>
        /// Update and return a task of type applicationuserupdatedto.
        /// </summary>
        /// <param name="applicationUserUpdateDTO">The application user update DTO.</param>
        /// <exception cref="Exception"></exception>
        /// <returns><![CDATA[Task<ApplicationUserUpdateDTO>]]></returns>
        public async Task<ApplicationUserUpdateDTO> Update(ApplicationUserUpdateDTO applicationUserUpdateDTO)
        {
            var user = await _userRepository.GetUserName(applicationUserUpdateDTO.UserName) ?? throw new Exception("This user not exits!");
            applicationUserUpdateDTO.Id = user.Id;
            user.DateAlteration = DateTime.Now;
            var existingCPF = await ExistingCPF(applicationUserUpdateDTO.CPF);
            _mapper.Map(applicationUserUpdateDTO, user);
            if (existingCPF && applicationUserUpdateDTO.Password != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, applicationUserUpdateDTO.Password);
            }
            await _userManager.UpdateAsync(user);
            var userRetorno = await _userRepository.GetUserName(user.UserName);
            return _mapper.Map<ApplicationUserUpdateDTO>(userRetorno);
        }

        /// <summary>
        /// Get personal data.
        /// </summary>
        /// <returns><![CDATA[Task<DataTable>]]></returns>
        public async Task<DataTable> GetPersonalData()
        {
            List<ApplicationUser> users = await _userRepository.GetDataPDF();
            var usersDTO = _mapper.Map<List<ApplicationUserDTO>>(users);
            return ConvertToDataTable(usersDTO);
        }

        /// <summary>
        /// Convert converts to data table.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>A DataTable</returns>
        private static DataTable ConvertToDataTable(List<ApplicationUserDTO> users)
        {
            DataTable table = new();
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("CPF", typeof(string));
            table.Columns.Add("MotherName", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Status", typeof(string));
            foreach (var user in users)
            {
                table.Rows.Add(user.Email, user.Name, user.CPF, user.MotherName, user.PhoneNumber, user.Status);
            }
            return table;
        }

        /// <summary>
        /// Export converts to pdf.
        /// </summary>
        /// <returns><![CDATA[Task<string>]]></returns>
        public async Task<string> ExportToPdf()
        {
            var data = await GetPersonalData();
            string fileName = "ListUsers-" + DateTime.Now.ToString("d");
            string filePath = System.IO.Path.Combine(@"C:\Users\pedro\Downloads", $"{fileName}.pdf");
            using (PdfWriter writer = new(new FileStream(filePath, FileMode.Create)))
            {
                PdfDocument pdf = new(writer);
                Document document = new(pdf, PageSize.A4);
                document.SetMargins(30, 30, 30, 30);
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                Paragraph title = new Paragraph("List of Users")
                    .SetFont(font)
                    .SetFontSize(24)
                    .SetFontColor(ColorConstants.DARK_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(title);
                Table table = new Table(data.Columns.Count)
                    .SetWidth(UnitValue.CreatePercentValue(100));
                // Add table headers
                AddColumn(data, table);
                // Add table data
                AddRows(data, table);
                document.Add(table);
                document.Close();
            }
            return filePath;
        }

        /// <summary>
        /// Add the column.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="table">The table.</param>
        private static void AddColumn(DataTable data, Table table)
        {
            foreach (DataColumn column in data.Columns)
            {
                Cell cell = new Cell()
                    .Add(new Paragraph(column.ColumnName))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY);
                table.AddHeaderCell(cell);
            }
        }

        /// <summary>
        /// Add the rows.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="table">The table.</param>
        private static void AddRows(DataTable data, Table table)
        {
            foreach (DataRow row in data.Rows)
            {
                foreach (var cell in from object item in row.ItemArray
                                     let cell = new Cell()
                                        .Add(new Paragraph(item.ToString()))
                                        .SetTextAlignment(TextAlignment.CENTER)
                                     select cell)
                {
                    table.AddCell(cell);
                }
            }
        }

        /// <summary>
        /// Validate CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> ValidateCPF(string cpf)
        {
            int[] multiplier1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
            int[] multiplier2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return await Task.FromResult(false);

            string tempCpf = cpf[..9];
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            int firstCheckDigit = (remainder < 2) ? 0 : 11 - remainder;

            tempCpf += firstCheckDigit.ToString();
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            int secondCheckDigit = (remainder < 2) ? 0 : 11 - remainder;

            string calculatedDigits = $"{firstCheckDigit}{secondCheckDigit}";

            bool isValid = cpf.EndsWith(calculatedDigits);
            return await Task.FromResult(isValid);
        }

        /// <summary>
        /// Existing CPF.
        /// </summary>
        /// <param name="cpf">The cpf.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> ExistingCPF(string cpf) { return await _userRepository.ExistingCPF(cpf); }
    }
}
