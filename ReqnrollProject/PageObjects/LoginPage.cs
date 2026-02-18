using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReqnrollProject.Support;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.PageObjects
{
    public class LoginPage: BasePage
    {
        public LoginPage(IWebDriver driver): base(driver)
        {
            //PageFactory.InitElements(driver, this);
        }

        /*[FindsBy(How = How.Id, Using = "userEmail")]
        private IWebElement Email;
        [FindsBy(How = How.Id, Using = "userPassword")]
        private IWebElement Password;
        [FindsBy(How = How.Id, Using = "login")]
        private IWebElement LoginButton;
        [FindsBy(How = How.XPath, Using = "(//button[@class = 'btn btn-custom'])[2]")]
        private IWebElement HomePageText;*/

        private By EmailField = By.Id("userEmail");
        private By PasswordField = By.Id("userPassword");
        private By LoginBtn = By.Id("login");
        



        public void navigateToLoginPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void LoginwithValidCredentials()
        {
            Wait.WaitForElementClickable(EmailField).SendKeys(Configreader.Username);
            Wait.WaitForElementClickable(PasswordField).SendKeys(Configreader.Password);
            Wait.WaitForElementClickable(LoginBtn).Click();
        }


        





    }
}
