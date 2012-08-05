namespace Rbi.Infrastructure.User
{
    public interface IUserProfile<TRole>
    {
        string UserName { get; }

        //todo refactor into collection?
        TRole Role { get; set; }
        
        //todo refactor off
        bool IsAdmin { get; }
    }
}