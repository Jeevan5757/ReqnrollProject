using OpenQA.Selenium;
using ReqnrollProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.PageObjects
{
    public class CartPage: BasePage
    {

        public CartPage(IWebDriver driver): base(driver)
        {
        }

        private By products => By.CssSelector("div.cartSection h3");

        public bool IsProductDisplayedInCart(string productName)
        {
            Wait.WaitForElementVisible(products);
            IList<IWebElement> elements = Driver.FindElements(products);

            return elements.Any(e =>
                e.Text.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
