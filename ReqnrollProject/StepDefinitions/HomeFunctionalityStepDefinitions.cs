using NUnit.Framework;
using Reqnroll;
using ReqnrollProject.PageObjects;
using ReqnrollProject.Support;
using System;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public class HomeFunctionalityStepDefinitions
    {
        private readonly HomePage _homePage;

        public HomeFunctionalityStepDefinitions(DriverContext driverContext)
        {
            _homePage = new HomePage(driverContext.Driver);
        }

        [Then("user should be redirected to the dashboard")]
        public void ThenUserShouldBeRedirectedToTheDashboard()
        {
            Logging.Info("Verifying user is successfully logged in and Home page is displayed");
            _homePage.validateHomePage();
            
        }




        [When("user adds {string} and {string} item to the cart")]
        public void WhenUserAddsAndItemToTheCart(string product1, string product2)
        {
            Logging.Info("Verifying user adding item to the cart");

            _homePage.addProductToCart(product1.ToLower());
            _homePage.addProductToCart(product2);
        }


        [Then("the product should be added to the cart")]
        public void ThenTheProductShouldBeAddedToTheCart()
        {
            Logging.Info("Verifying user added item successfully");
            _homePage.goToCart();
        }
    }
}
