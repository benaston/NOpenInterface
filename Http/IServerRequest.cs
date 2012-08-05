using System;

namespace Rbi.Infrastructure.Http
{
    public interface IServerRequest
    {
        string HostUrl();
        Uri RequestUrl();
        Uri Referrer();
        bool HasNoReferrer();
        string QueryString(string key);
    }
}
