using System;
using AllureExtensionsFluentAssertionsHomework.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public abstract class BasePage
    {
        [ThreadStatic] private static IWebDriver _driver;
        private static WaitService _waitService;

        public static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value ?? throw new ArgumentNullException(nameof(value));
        }
        
        public static WaitService WaitService => _waitService;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            _waitService = new WaitService(_driver);
        }

        public void WaitUntilOpened()
        {
            var isPageOpenedIndicator = IsPageOpened();

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page wasn't opened");
            }
        }

        public void OpenAndWait()
        {
            OpenPage();
            WaitUntilOpened();
        }
        
        protected abstract bool IsPageOpened();
        
        protected abstract void OpenPage();
    }
}
