namespace Rbi.Infrastructure.User
{
    public interface IUserProfileService<TRole>
    {
        IUserProfile<TRole> GetLoggedInUser();

        IUserProfile<TRole> GetUserProfileFor(string username);
    }
}