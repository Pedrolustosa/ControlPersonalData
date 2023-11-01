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
        /// Gets or Sets the CPF.
        /// </summary>
        public string CPF { get; set; } = string.Empty;
    }
}
