using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandlingHomework.Services;

namespace WaitsAlertsWindowsHandlingHomework.Pages
{
    public abstract class BasePage
    {
        [ThreadStatic] private static IWebDriver _driver;
        private static WaitService _waitService;

        private const int WaitTillPageLoaded = 60;

        public static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        public static WaitService WaitService => _waitService;
        
        protected BasePage(IWebDriver driver, bool openPageByUrl)
        {
            _driver = driver;
            _waitService = new WaitService(_driver);
            
            if (openPageByUrl)
            {
                OpenPage();
            }

            WaitUntilOpened();
        }

        private void WaitUntilOpened()
        {
            var secondsCount = 0;
            var isPageOpenedIndicator = IsPageOpened();

            while (isPageOpenedIndicator != true && secondsCount < WaitTillPageLoaded / Configurator.WaitTime)
            {
                secondsCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page wasn't opened");
            }
        }
        
        protected abstract bool IsPageOpened();
        
        protected abstract void OpenPage();
    }
}
