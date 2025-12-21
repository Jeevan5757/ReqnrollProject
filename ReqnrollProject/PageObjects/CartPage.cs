using OpenQA.Selenium;
using ReqnrollProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.PageObjects
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WaitHelper _waitHelper;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _waitHelper = new WaitHelper(_driver);
        }

        private By products => By.CssSelector("div.cartSection h3");

        public bool IsProductDisplayedInCart(string productName)
        {
            _waitHelper.WaitForElementVisible(products);
            IList<IWebElement> elements = _driver.FindElements(products);

            return elements.Any(e =>
                e.Text.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
