using Serilog;
using System;

namespace SmartSchool.LoggingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeLogging();

            Log.Information("Program started ...");

            // do something

            try
            {
                throw new Exception("Simulated exception");
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }

            Log.Information("Program finished");

        }

        private static void InitializeLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
