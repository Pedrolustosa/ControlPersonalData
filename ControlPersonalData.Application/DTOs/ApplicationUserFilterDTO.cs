#nullable disable
namespace ControlPersonalData.Application.DTOs
{
    /// <summary>
    /// The application user filter DTO.
    /// </summary>
    public class ApplicationUserFilterDTO 
    {
        /// <summary>
        /// Gets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or Sets the mother name.
        /// </summary>
        public string MotherName { get; set; }
    }
}
