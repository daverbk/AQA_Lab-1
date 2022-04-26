using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WrappersHomework.Services.Configuration;
using WrappersHomework.Wrappers;

namespace WrappersHomework.Pages
{
    public class CheckBoxesPage : BasePage
    {
        private const string Endpoint = "/checkboxes";

        private static readonly By FirstCheckBoxLocator = By.XPath("(//form/ input)[1]");
        private static readonly By SecondCheckBoxLocator = By.XPath("(//form/ input)[2]");

        public CheckBox FirstCheckBox => new(Driver, FirstCheckBoxLocator);
        public CheckBox SecondCheckBox => new(Driver, SecondCheckBoxLocator);
    
        public CheckBoxesPage(IWebDriver driver) : base(driver)
        {
        }

        public override void NavigateToPage()
        {
            Driver.Navigate().GoToUrl(AppSettings.BaseUrl + Endpoint);
        }

        public override bool CheckIfPageOpened()
        {
            try
            {
                return SecondCheckBox.Displayed;
            }
            catch (TimeoutException)
            {
                throw new AssertionException("The page wasn't opened.");
            }
        }
    }
}
