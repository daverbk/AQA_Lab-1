using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WrappersHomework.Wrappers;

namespace WrappersHomework.Pages
{
    public class TestRailCasesPage: BasePage
    {
        private const string Endpoint = "https://aqa18.testrail.io/index.php?/suites/view/22";
    
        private static readonly By DropDownLocator = By.Id("reportDropdown");

        public DropDown DropDown => new(Driver, DropDownLocator);

        public TestRailCasesPage(IWebDriver driver) : base(driver)
        {
        }

        public override void NavigateToPage()
        {
            Driver.Navigate().GoToUrl(Endpoint);
        }

        public override bool CheckIfPageOpened()
        {
            try
            {
                return DropDown.Displayed;
            }
            catch (TimeoutException)
            {
                throw new AssertionException("The page wasn't opened.");
            }
        }
    }
}
