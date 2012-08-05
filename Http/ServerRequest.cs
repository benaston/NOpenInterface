using System;
using System.Web;

namespace Rbi.Infrastructure.Http
{
    public class ServerRequest:IServerRequest
    {
        public string HostUrl()
        {
            return string.Format("{0}://{1}/", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host);
        }

        public Uri RequestUrl()
        {
            return HttpContext.Current.Request.Url;
        }

        public Uri Referrer()
        {
            return HttpContext.Current.Request.UrlReferrer;
        }

        public bool HasNoReferrer() { 
            return Referrer() == null || Referrer().Host != RequestUrl().Host;
        }

        public string QueryString(string key)
        {
            return HttpContext.Current.Request.QueryString.Get(key);
        }
    }
}