using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using Selenium;

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

        public void Run(Action<ISelenium> test)
        {
            var browsers = new List<string> { /*"*googlechrome",*/ "*firefox" };
            foreach (var browser in browsers)
            {
                var s = new DefaultSelenium("localhost", 4444, browser, ConfigurationManager.AppSettings["testSite"]);
                s.Start();
                test(s);
                s.Stop();
            }
        }
    }
}