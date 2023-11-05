namespace ControlPersonalData.API.Models
{ 
    /// <summary>
    /// The user token.
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// Gets or Sets the token.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Gets or Sets the expiration.
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}
