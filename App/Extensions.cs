using Microsoft.Extensions.Logging;

namespace App;

public static class Extensions
{
    public static void AddEventLogger(this ILoggingBuilder loggingBuilder)
    {
        #if _WINDOWS
        loggingBuilder.AddEventLog();
        #endif
    }
}