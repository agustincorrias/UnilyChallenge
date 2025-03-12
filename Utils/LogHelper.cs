using Serilog;

namespace UnilyChallenge.Utils;
public static class LogHelper
{
    static LogHelper()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }

    public static void LogInformation(string message)
    {
        Log.Information(message);
    }

    public static void LogError(string message, Exception ex = null)
    {
        if (ex != null)
        {
            Log.Error(ex, message);
        }
        else
        {
            Log.Error(message);
        }
    }
}