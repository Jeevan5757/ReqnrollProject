using NUnit.Framework;
using Reqnroll;
using ReqnrollProject.PageObjects;
using ReqnrollProject.Support;
using System;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public class LoginFunctionalityStepDefinitions
       
    {
        private readonly LoginPage _loginPage;

        public LoginFunctionalityStepDefinitions(DriverContext driverContext)
        {
            _loginPage = new LoginPage(driverContext.Driver);
        }

        

        [When("user enters valid username and password")]
        public void WhenUserEntersValidUsernameAndPassword()
        {
            _loginPage.LoginwithValidCredentials();
        }

        
    }
}
