namespace ControlPersonalData.Domain.Account
{
    public interface IUser
    {
        Task<bool> Authenticate(string email, string password);

        Task<bool> RegisterUser(string email, string password);

        Task Logout();
    }
}
