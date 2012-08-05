namespace NBasicInterfaces
{
    using System;

    public interface IClock
    {
        DateTime ApplicationNow { get; }

        DateTime UtcNow { get; }
    }

    public abstract class DotNetClock : IClock
    {
        DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}