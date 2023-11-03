using Microsoft.AspNetCore.Identity;

namespace ControlPersonalData.Infra.Data.Identity
{
    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
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
