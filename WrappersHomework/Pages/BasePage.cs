using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WrappersHomework.Services;

namespace WrappersHomework.Pages
{
    public abstract class BasePage
    {
        [ThreadStatic] private static IWebDriver _driver;
        private static WaitService _waitService;

        protected static IWebDriver Driver
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

        public void NavigateToPageAndWaitUntilOpened()
        {
            NavigateToPage();
            CheckIfPageOpened();
        }

        public abstract void NavigateToPage();
        
        public abstract bool CheckIfPageOpened();
    }
}
