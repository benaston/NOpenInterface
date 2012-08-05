namespace Rbi.Infrastructure.User
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
    }
}