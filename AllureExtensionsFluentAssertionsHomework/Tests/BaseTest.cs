using System;
using AllureExtensionsFluentAssertionsHomework.Services;
using AllureExtensionsFluentAssertionsHomework.Steps;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Tests
{
    public class BaseTest
    {
        [ThreadStatic] private static IWebDriver _driver;
        protected StandardUserSteps StandardUserSteps;
        
        
        
        [SetUp]
        public void SetUp()
        {
            _driver = new BrowserService().Driver;
            StandardUserSteps = new StandardUserSteps(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        protected static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
