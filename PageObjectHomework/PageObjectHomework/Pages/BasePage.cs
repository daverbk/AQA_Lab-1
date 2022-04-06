using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObjectHomework.Pages
{
    public abstract class BasePage
    {
        [ThreadStatic] private static IWebDriver _driver;

        private const int WaitTillPageLoaded = 60;
        
        protected abstract void OpenPage();

        protected abstract bool IsPageOpened();

        protected BasePage(IWebDriver driver, bool openPageByUrl)
        {
            _driver = driver;

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

            while (isPageOpenedIndicator != true && secondsCount < WaitTillPageLoaded)
            {
                Thread.Sleep(1000);
                secondsCount++;
                isPageOpenedIndicator = IsPageOpened();
            }

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page wasn't opened");
            }
        }

        public static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
