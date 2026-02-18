using OpenQA.Selenium;
using ReqnrollProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.PageObjects
{
    public class HomePage: BasePage
    {

        public HomePage(IWebDriver driver): base(driver)
        { 
        }

        private By HomePageText = By.XPath("(//button[@class = 'btn btn-custom'])[2]");
        private By AddToCartButton(String productName) =>
            By.XPath($"//b[text() = '{productName}']/ancestor::div[@class = 'card-body']/button[text() = ' Add To Cart']");

        private By CartButton => By.XPath("//button[@routerlink='/dashboard/cart']");

        private By Spinner => By.CssSelector(".ngx-spinner-overlay");

        public String validateHomePage()
        {
            String text = Wait.WaitForElementVisible(HomePageText).Text;

            return text;
        }

        public void addProductToCart(string productName)

        {
            Thread.Sleep(2000);
            Wait.WaitForElementClickable(AddToCartButton(productName)).Click();
        }

        public void goToCart()
        {
            Thread.Sleep(2000);
            Wait.WaitForElementClickable(CartButton).Click();
        }
    }
}
