using Allure.Commons;
using AllureExtensionsFluentAssertionsHomework.Pages;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Steps
{
    public class LoginSteps : BaseStep
    {
        public LoginSteps(IWebDriver driver) : base(driver)
        {
        }

        public ProductsPage InsertUserNameAndPassword(string login, string password)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                LoginPage.UserNameInput.SendKeys(login);
                LoginPage.PasswordInput.SendKeys(password);
                LoginPage.LoginButton.Click();
            }, $"Insert username: {login} and password: {password}");

            return ProductsPage;
        }
    }
}
