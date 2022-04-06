using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectHomework.Services;

namespace PageObjectHomework.Tests
{
    public class BaseTest
    {
        [ThreadStatic] private static IWebDriver _driver;
        
        [SetUp]
        public void SetUp()
        {
            _driver = new BrowserService().Driver;
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
