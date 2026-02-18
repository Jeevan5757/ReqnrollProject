using NUnit.Framework.Internal;
using ReqnrollProject.PageObjects;
using ReqnrollProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public class CommonStepdefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly HomePage _homePage;
        private readonly CartContext _cartContext;

        public CommonStepdefinitions(DriverContext driverContext,
                                     CartContext cartContext)
        {
            _loginPage = new LoginPage(driverContext.Driver);
            _homePage = new HomePage(driverContext.Driver);
            _cartContext = cartContext;
        }
        [Given("user is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            Logging.Info("User navigating to Login Page");
            _loginPage.navigateToLoginPage(Configreader.BaseUrl);
        }

        [Given("user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            Logging.Info("Navigating to Login page");
             GivenUserIsOnTheLoginPage();
            Logging.Info("User attempts to login with valid credentials");
            _loginPage.LoginwithValidCredentials();
            Logging.Info("Verifying user is successfully logged in and Home page is displayed");
            _homePage.validateHomePage();

        }
        [Given("user has following item in the cart")]
        public void GivenUserHasFollowingItemInTheCart(DataTable dataTable)
        {
            Logging.Info("Ensuring user is logged in before adding items to cart");
            GivenUserIsLoggedIn();
            foreach(var row in dataTable.Rows)
            {
                string productName = row["productName"];
                _cartContext.Products.Add(productName);
                Logging.Info($"Adding product '{productName}' to the cart");
                _homePage.addProductToCart(productName);
            }
        }

    }
}
