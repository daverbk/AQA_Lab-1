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
        protected LoginSteps LoginSteps;
        protected ProductsSteps ProductsSteps;
        protected CheckoutSteps CheckoutSteps;

        [SetUp]
        public void SetUp()
        {
            _driver = new BrowserService().Driver;

            LoginSteps = new LoginSteps(_driver);
            ProductsSteps = new ProductsSteps(_driver);
            CheckoutSteps = new CheckoutSteps(_driver);

            _driver.Navigate().GoToUrl(Configurator.BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
