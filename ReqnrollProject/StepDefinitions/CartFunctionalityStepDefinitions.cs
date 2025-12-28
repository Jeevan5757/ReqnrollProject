using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject.PageObjects;
using ReqnrollProject.Support;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]

    public class CartFunctionalityStepDefinitions
    {
        private readonly CartPage _cartPage;
        private readonly HomePage _homePage;
        private readonly CartContext _cartContext;

        public CartFunctionalityStepDefinitions(DriverContext driverContext,
                                                CartContext cartContext)
        {
            _cartPage = new CartPage(driverContext.Driver);
            _homePage = new HomePage(driverContext.Driver);
            _cartContext = cartContext;
        }


        [Then("verify cart page displays the added item")]
        public void ThenVerifyCartPageDisplaysTheAddedItem()
        {
            Logging.Info("Verifying cart page diplaying added item");
            _homePage.goToCart();
            foreach (var product in _cartContext.Products)
            {
                Assert.That(
                    _cartPage.IsProductDisplayedInCart(product),
                    $"{product} was not found in the cart");
            }
        }
    }
}
