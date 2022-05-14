using BDDHomework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BDDHomework.Services.SeleniumServices
{
    public class WaitService
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _explicitWait;
        private readonly DefaultWait<IWebDriver> _fluentWait;

        public WaitService(IWebDriver driver)
        {
            _driver = driver;

            _explicitWait =
                new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.AppSettings.SeleniumWaitTimeout));

            _fluentWait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(Configurator.AppSettings.SeleniumWaitTimeout),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public IWebElement WaitUntilElementExists(By locator)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        public IWebElement WaitUntilElementClickable(By locator)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
