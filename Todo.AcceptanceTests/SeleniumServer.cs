using System.Configuration;
using System.Diagnostics;

namespace Todo.AcceptanceTests
{
    public class SeleniumServer
    {
        private static Process _process;

        public static bool IsStarted { get; set; }

        private static readonly string JavaPath = ConfigurationManager.AppSettings["java"];
        private static readonly string JavaArguments = ConfigurationManager.AppSettings["selenium"];

        public static void Start()
        {
            if (IsStarted)
                return;

            IsStarted = true;

            _process = new Process {
                StartInfo = {
                    FileName = JavaPath, 
                    Arguments = JavaArguments, 
                    CreateNoWindow = false
                }
            };

            _process.Start();
        }

        public static void Stop()
        {
            _process.Kill();

            IsStarted = false;
        }
    }
}