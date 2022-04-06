using System;
using OpenQA.Selenium;
using PageObjectHomework.Services;

namespace PageObjectHomework.Pages
{
    public class LoginPage : BasePage
    {
        private const string Endpoint = "/";
        
        private static readonly By UserNameInputLocator = By.Id("user-name");
        private static readonly By PasswordInputLocator = By.Id("password");
        private static readonly By LoginButtonLocator = By.Id("login-button");
        
        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
        
        public IWebElement UserNameInput => Driver.FindElement(UserNameInputLocator);
        public IWebElement PasswordInput => Driver.FindElement(PasswordInputLocator);
        public IWebElement LoginButton => Driver.FindElement(LoginButtonLocator);
    }
}
