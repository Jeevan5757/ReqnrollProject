using OpenQA.Selenium;
using ReqnrollProject.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WaitHelper Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WaitHelper(driver);
        }
    }
}
