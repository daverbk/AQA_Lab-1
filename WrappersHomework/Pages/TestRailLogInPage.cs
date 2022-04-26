using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WrappersHomework.Pages
{
    public class TestRailLogInPage : BasePage
    {
        private const string Endpoint = "https://testrail.io/";

        private static readonly By LoginFieldLocator = By.Id("name");
        private static readonly By PasswordFieldLocator = By.Id("password");
        private static readonly By LogInButtonLocator = By.Id("button_primary");
        
        public IWebElement LoginFiled => WaitService.WaitUntilElementExists(LoginFieldLocator);
        public IWebElement PasswordFiled => WaitService.WaitUntilElementExists(PasswordFieldLocator);
        public IWebElement LogInButton => WaitService.WaitUntilElementExists(LogInButtonLocator);
    
        public TestRailLogInPage(IWebDriver driver) : base(driver)
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
                return PasswordFiled.Displayed;
            }
            catch (TimeoutException)
            {
                throw new AssertionException("The page wasn't opened.");
            }
        }
    }
}
