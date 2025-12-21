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
            _loginPage.navigateToLoginPage(ConfigReader.BaseUrl);
        }

        [Given("user is logged in")]
        public void GivenUserIsLoggedIn()
        {
             GivenUserIsOnTheLoginPage();
            _loginPage.LoginwithValidCredentials();
            _homePage.validateHomePage();

        }
        [Given("user has following item in the cart")]
        public void GivenUserHasFollowingItemInTheCart(DataTable dataTable)
        {
            GivenUserIsLoggedIn();
            foreach(var row in dataTable.Rows)
            {
                string productName = row["productName"];
                _cartContext.Products.Add(productName);
                _homePage.addProductToCart(productName);
            }
        }

    }
}
