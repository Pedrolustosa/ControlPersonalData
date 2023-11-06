#nullable disable
using System.Text.Json.Serialization;

namespace ControlPersonalData.Application.DTOs
{
    /// <summary>
    /// The application user DTO.
    /// </summary>
    public class ApplicationUserUpdateDTO : ApplicationUserDTO
    {
        /// <summary>
        /// Gets or Sets the id.
        /// </summary>
        [JsonIgnore]
        public string Id { get; set; }

    }
}
