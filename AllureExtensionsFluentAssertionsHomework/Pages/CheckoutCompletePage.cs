using System;
using AllureExtensionsFluentAssertionsHomework.Services;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private const string Endpoint = "checkout-complete.html/";
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By BackHomeButtonLocator = By.Id("back-to-products");

        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement BackHomeButton => WaitService.WaitUntilElementExists(BackHomeButtonLocator);
        
        public CheckoutCompletePage(IWebDriver driver) : base(driver)
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
                return  BackHomeButton.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
