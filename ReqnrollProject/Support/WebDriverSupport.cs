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
                bool isHeadless = Configreader.Headless.ToLower() == "true";
                Logging.Info($"Headless mode is {(isHeadless ? "enabled" : "disabled")}.");
                switch (Configreader.Browser.ToLower())
                {
                    case "chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());

                        ChromeOptions chromeOptions = new ChromeOptions();
                        if (isHeadless)
                        {
                            Logging.Info("Running Chrome in headless mode.");
                            chromeOptions.AddArgument("--headless=new");   // IMPORTANT
                            chromeOptions.AddArgument("--window-size=1920,1080");
                            chromeOptions.AddArgument("--disable-gpu");
                            chromeOptions.AddArgument("--no-sandbox");
                            chromeOptions.AddArgument("--disable-dev-shm-usage");
                        }

                        _driver = new ChromeDriver(chromeOptions);
                        break;
                    case "firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        if (isHeadless)
                        {
                            firefoxOptions.AddArgument("-headless");
                        }
                        _driver = new FirefoxDriver(firefoxOptions);
                        break;
                    case "edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        EdgeOptions edgeOptions = new EdgeOptions();
                        if (isHeadless)
                        {
                            Logging.Info("Running Edge in headless mode.");
                            edgeOptions.AddArgument("--headless=new");
                            edgeOptions.AddArgument("--window-size=1920,1080");
                            edgeOptions.AddArgument("--disable-gpu");
                            edgeOptions.AddArgument("--no-sandbox");
                            edgeOptions.AddArgument("--disable-dev-shm-usage");
                        }
                        _driver = new EdgeDriver(edgeOptions);
                        break;
                    default:
                        throw new ArgumentException($"Unsupported browser: {Configreader.Browser.ToLower()}");

                }
                _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
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
