using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject.Support;

namespace ReqnrollProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
       private readonly DriverContext _driverContext;
        private readonly WebDriverSupport _WebDriverSupport;

        public Hooks(DriverContext driverContext)
        {
            this._driverContext = driverContext;
            this._WebDriverSupport = new WebDriverSupport();
        }




        [BeforeScenario]
        public void InitializeBrowser()
        {
            _driverContext.Driver =
                    _WebDriverSupport.getDriver();

        }


        [AfterScenario]
        public void AfterScenario()
        {
            _WebDriverSupport.QuitDriver();
        }
    }
}