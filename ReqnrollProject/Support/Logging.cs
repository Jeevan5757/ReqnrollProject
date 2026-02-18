using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Support
{
    public static class Logging
    {
        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Warn(string message)
        {
            Write("WARN", message);
        }

        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        private static void Write(string level, string message)
        {
            string log =
                $"[{level}] {DateTime.Now:HH:mm:ss} | {message}";

            // Console / Test Explorer
            TestContext.Progress.WriteLine(log);

            // Extent Report (if available)
            Hooks.ExtentReportHooks.Log(level, message);
        }

    }
}
