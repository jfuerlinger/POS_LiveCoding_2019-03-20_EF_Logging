using Serilog;

namespace Utils
{
    public class MyLogger
    {
        public static SqlCommandsObserver SqlCommandsLogObserver { get; private set; }

        public static void InitializeLogger()
        {
            SqlCommandsLogObserver = new SqlCommandsObserver();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("Serilog.log")
                .WriteTo.Observers(events =>
                    events
                        .Subscribe(SqlCommandsLogObserver))
                .CreateLogger();
        }
    }
}
