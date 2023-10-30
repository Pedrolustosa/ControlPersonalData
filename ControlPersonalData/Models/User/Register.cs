using System.ComponentModel.DataAnnotations;

namespace ControlPersonalData.Models.User
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Compare("Password", ErrorMessage = "Password don't match")]
        public string? ConfirmPassword { get; set; }
    }
}
