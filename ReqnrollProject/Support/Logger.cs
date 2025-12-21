using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Support
{
    public static class Logger
    {
        public static void Info(string message)
        {
            TestContext.Progress.WriteLine($"[INFO] {DateTime.Now:HH:mm:ss} - {message}");
        }

        public static void Warn(string message)
        {
            TestContext.Progress.WriteLine($"[WARN] {DateTime.Now:HH:mm:ss} - {message}");
        }

        public static void Error(string message)
        {
            TestContext.Progress.WriteLine($"[ERROR] {DateTime.Now:HH:mm:ss} - {message}");
        }

    }
}
