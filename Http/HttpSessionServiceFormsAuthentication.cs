using System;
using System.Web;
using System.Web.Security;

namespace Rbi.Infrastructure.Http
{
    /// <summary>
    /// Wraps the untestable Microsoft FormsAuthentication session 
    /// control API.
    /// </summary>
    public class HttpSessionServiceFormsAuthentication : IHttpSessionService
    {
        private readonly Func<HttpContextBase> _httpContextRetrievalFunction;

        public HttpSessionServiceFormsAuthentication(Func<HttpContextBase> httpContextRetrievalFunction)
        {
            if (httpContextRetrievalFunction == null)
            {
                throw new ArgumentNullException("httpContextRetrievalFunction");
            }

            _httpContextRetrievalFunction = httpContextRetrievalFunction;
        }

        public void BeginFor(string username)
        {
            SetAuthenticationCookie(username);
        }

        /// <summary>
        /// Terminates the HTTP session for the current user.
        /// </summary>
        public void End()
        {
            DeleteAuthenticationCookie();
        }

        private void SetAuthenticationCookie(string userName)
        {
            FormsAuthentication.SetAuthCookie(userName, false);
        }

        private void DeleteAuthenticationCookie()
        {
            FormsAuthentication.SignOut();
        }
    }
}