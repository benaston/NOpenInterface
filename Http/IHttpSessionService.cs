namespace Rbi.Infrastructure.Http
{
    public interface IHttpSessionService
    {
        void BeginFor(string username);

        void End();
    }
}