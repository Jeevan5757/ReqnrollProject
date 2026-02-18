using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Support
{
    public static class Configreader
    {
        private static IConfiguration _config;

        static Configreader()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath($"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Resources")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        
        public static string Browser =>
            _config["browser"];

        public static string BaseUrl =>
            _config["baseUrl"];

        public static string Username =>
            _config["credentials:username"];

        public static string Password =>
            _config["credentials:password"];

        public static int ExplicitTimeout =>
            int.Parse(_config["timeouts:explicit"]);

        public static string Headless =>
            _config["headless"];


    }
}
