namespace Rbi.Infrastructure.User
{
    public interface IAuthorizationService<in TRole>
    {
        bool IsInRole(string username, TRole role);
    }
}