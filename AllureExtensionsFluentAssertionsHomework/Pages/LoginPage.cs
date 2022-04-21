using System;
using AllureExtensionsFluentAssertionsHomework.Services;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class LoginPage : BasePage
    {
        private const string Endpoint = "/";
        
        private static readonly By UserNameInputLocator = By.Id("user-name");
        private static readonly By PasswordInputLocator = By.Id("password");
        private static readonly By LoginButtonLocator = By.Id("login-button");
        
        public IWebElement UserNameInput => WaitService.WaitUntilElementExists(UserNameInputLocator);
        public IWebElement PasswordInput => WaitService.WaitUntilElementExists(PasswordInputLocator);
        public IWebElement LoginButton => WaitService.WaitUntilElementExists(LoginButtonLocator);
        
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.BaseUrl + Endpoint);
        }

        protected override bool IsPageOpened()
        {
            try
            {
                return LoginButton.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
