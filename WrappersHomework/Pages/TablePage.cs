using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WrappersHomework.Services.Configuration;
using WrappersHomework.Wrappers;

namespace WrappersHomework.Pages
{
    public class TablePage : BasePage
    {
        private const string Endpoint = "/challenging_dom";
    
        private static readonly By TableLocator = By.TagName("table");

        public Table Table => new(Driver, TableLocator);
    
        public TablePage(IWebDriver driver) : base(driver)
        {
        }

        protected override void NavigateToPage()
        {
            Driver.Navigate().GoToUrl(AppSettings.BaseUrl + Endpoint);
        }

        public override bool CheckIfPageOpened()
        {
            try
            {
                return Table.Displayed;
            }
            catch (TimeoutException timeoutException)
            {
                throw new AssertionException("The page wasn't opened.");
            }
        }
    }
}
