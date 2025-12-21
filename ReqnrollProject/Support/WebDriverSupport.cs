using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace ReqnrollProject.Support
{
    internal class WebDriverSupport
    {
        private IWebDriver _driver;

        public IWebDriver getDriver()
        {

            if (_driver == null)
            {
                switch (ConfigReader.Browser.ToLower())
                {
                    case "chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        _driver = new ChromeDriver();
                        break;
                    case "firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        _driver = new FirefoxDriver();
                        break;
                    case "edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        _driver = new EdgeDriver();
                        break;
                    default:
                        throw new ArgumentException($"Unsupported browser: {ConfigReader.Browser.ToLower()}");

                }
                _driver.Manage().Window.Maximize();
            }
                return _driver;
            
        }
        public void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
