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
            String text = _homePage.validateHomePage();
            TestContext.Progress.WriteLine(text);
        }




        [When("user adds {string} and {string} item to the cart")]
        public void WhenUserAddsAndItemToTheCart(string product1, string product2)
        {
            
            _homePage.addProductToCart(product1.ToLower());
            _homePage.addProductToCart(product2);
        }


        [Then("the product should be added to the cart")]
        public void ThenTheProductShouldBeAddedToTheCart()
        {
            _homePage.goToCart();
        }
    }
}
