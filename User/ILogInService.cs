namespace Rbi.Infrastructure.User
{
    public interface ILogInService
    {
        bool LogIn(string username, string password);

        void LogOut();
    }
}