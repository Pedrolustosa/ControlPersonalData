using Microsoft.AspNetCore.Identity;

namespace ControlPersonalData.Infra.Data.Identity
{
    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Gets or Sets the CPF.
        /// </summary>
        public string CPF { get; set; } = string.Empty;
    }
}
