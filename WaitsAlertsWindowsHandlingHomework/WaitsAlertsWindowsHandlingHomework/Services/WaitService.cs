using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WaitsAlertsWindowsHandlingHomework.Services
{
    public class WaitService
    {
        private IWebDriver _driver;
        private readonly WebDriverWait _explicitWait;
        private readonly DefaultWait<IWebDriver> _fluentWait;

        public WaitService(IWebDriver driver)
        {
            _driver = driver;
            
            _explicitWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.WaitTime));
            
            _fluentWait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(Configurator.WaitTime),
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }

        public IWebElement WaitUntilElementExists(By locator)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }
        
        public ReadOnlyCollection<IWebElement> WaitUntilElementsPresent(By locator)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }
        
        public IWebElement WaitUntilElementVisible(By locator)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }
        
        public bool WaitUntilElementInvisible(By locator)
        {
            return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public IWebElement WaitFastElement(By locator)
        {
            return _fluentWait.Until(x => x.FindElement(locator));
        }
    }
}
