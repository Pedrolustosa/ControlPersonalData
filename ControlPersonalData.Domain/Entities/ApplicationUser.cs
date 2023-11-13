using Microsoft.AspNetCore.Identity;
using ControlPersonalData.Domain.Validation;

#nullable disable 
namespace ControlPersonalData.Domain.Entities
{
    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="name">The name.</param>
        /// <param name="cPF">The c PF.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="age">The age.</param>
        /// <param name="motherName">The mother name.</param>
        /// <param name="status">If true, status.</param>
        public ApplicationUser(string email, string userName, string phoneNumber,
            string name, string cPF, DateTime birthDate, string motherName, bool status)
        {
            ValidateDomain(email, userName, phoneNumber, name, cPF, birthDate, motherName, status);
        }

        /// <summary>
        /// Validates the domain.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userName">The user name.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="name">The name.</param>
        /// <param name="cPF">The c PF.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="age">The age.</param>
        /// <param name="motherName">The mother name.</param>
        /// <param name="status">If true, status.</param>
        public void ValidateDomain(string email, string userName, string phoneNumber,
            string name, string cPF, DateTime birthDate, string motherName, bool status)
        {
            DomainExceptionValidation.When(cPF.Length != 11, "CPF cannot be shorter or longer than 11 characters!");
            DomainExceptionValidation.When((DateTime.Now.Year - birthDate.Year) < 18, "The User must not be under the age of eighteen");

            Email = email;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Name = name;
            CPF = cPF;
            BirthDate = birthDate;
            DateInsert = DateTime.Now;
            MotherName = motherName;
            Status = status;
        }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets the CPF.
        /// </summary>
        public string CPF { get; private set; }

        /// <summary>
        /// Gets or Sets the birth date.
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// Gets or Sets the date insert.
        /// </summary>
        public DateTime DateInsert { get; set; }

        /// <summary>
        /// Gets or Sets the date alteration.
        /// </summary>
        public DateTime DateAlteration { get; set; }

        /// <summary>
        /// Gets or Sets the mother name.
        /// </summary>
        public string MotherName { get; private set; }

        /// <summary>
        /// Gets or Sets a value indicating whether status.
        /// </summary>
        public bool Status { get; private set; }
    }
}