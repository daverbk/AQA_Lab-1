using System;
using OpenQA.Selenium;
using PageObjectHomework.Services;

namespace PageObjectHomework.Pages
{
    public class CheckoutStepOnePage : BasePage
    {
        private const string Endpoint = "checkout-step-one.html/";
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By ContinueButtonLocator = By.Id("continue");
        private static readonly By FirstNameTextBoxLocator = By.Id("first-name");
        private static readonly By LastNameTextBoxLocator = By.Id("last-name");
        private static readonly By PostalCodeTextBoxLocator = By.Id("postal-code");

        public CheckoutStepOnePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
                return ContinueButton.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public IWebElement PageName => Driver.FindElement(PageNameLocator);
        public IWebElement ContinueButton => Driver.FindElement(ContinueButtonLocator);
        public IWebElement FirstNameTextBox => Driver.FindElement(FirstNameTextBoxLocator);
        public IWebElement LastNameTextBox => Driver.FindElement(LastNameTextBoxLocator);
        public IWebElement PostalCodeTextBox => Driver.FindElement(PostalCodeTextBoxLocator);
    }
}
