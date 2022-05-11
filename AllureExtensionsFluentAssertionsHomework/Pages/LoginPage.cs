using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By UserNameInputLocator = By.Id("user-name");
        private static readonly By PasswordInputLocator = By.Id("password");
        private static readonly By LoginButtonLocator = By.Id("login-button");
        
        public IWebElement UserNameInput => WaitService.WaitUntilElementExists(UserNameInputLocator);
        public IWebElement PasswordInput => WaitService.WaitUntilElementExists(PasswordInputLocator);
        public IWebElement LoginButton => WaitService.WaitUntilElementExists(LoginButtonLocator);
        
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        protected override By GetPageIdentifier()
        {
            return LoginButtonLocator;
        }
    }
}
