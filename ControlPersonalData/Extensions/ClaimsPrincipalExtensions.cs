using System.Security.Claims;

#nullable disable
namespace ControlPersonalData.API.Extensions
{
    /// <summary>
    /// The claims principal extensions.
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Gets the user name.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A string.</returns>
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>An integer.</returns>
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
