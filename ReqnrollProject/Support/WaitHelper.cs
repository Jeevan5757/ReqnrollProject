using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.Support
{
    public  class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configreader.ExplicitTimeout));
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitForElementClickable(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public bool WaitForUrlContains(string value)
        {
            return _wait.Until(ExpectedConditions.UrlContains(value));
        }

        public void WaitForTextPresent(By locator, string text)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }

        public void WaitForElementInvisible(By locator)
        {
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}
