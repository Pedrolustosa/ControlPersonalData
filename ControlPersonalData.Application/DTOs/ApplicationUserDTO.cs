#nullable disable
namespace ControlPersonalData.Application.DTOs
{
    /// <summary>
    /// The application user DTO.
    /// </summary>
    public class ApplicationUserDTO
    {
        /// <summary>
        /// Gets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or Sets the CPF.
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Gets or Sets the birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or Sets the age.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Gets or Sets the mother name.
        /// </summary>
        public string MotherName { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether status.
        /// </summary>
        public bool Status { get; set; }
    }
}
