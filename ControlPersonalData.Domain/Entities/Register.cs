using System.ComponentModel.DataAnnotations;

namespace ControlPersonalData.Models.Entities
{
    /// <summary>
    /// The register.
    /// </summary>
    public class Register
    {
        /// <summary>
        /// Gets or Sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Compare("Password", ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the CPF.
        /// </summary>
        public string CPF { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or Sets the date insert.
        /// </summary>
        public DateTime DateInsert { get; set; }

        /// <summary>
        /// Gets or Sets the date alteration.
        /// </summary>
        public DateTime DateAlteration { get; set; }

        /// <summary>
        /// Gets or Sets the age.
        /// </summary>
        public string Age { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the mother name.
        /// </summary>
        public string MotherName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the phone.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets a value indicating whether status.
        /// </summary>
        public bool Status { get; set; }
    }
}
