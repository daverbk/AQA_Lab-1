using System;
using AllureExtensionsFluentAssertionsHomework.Services;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class CartPage : BasePage
    {
        private const string Endpoint = "cart.html/";
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By CheckoutButtonLocator = By.Id("checkout");
        
        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement CheckoutButton => WaitService.WaitUntilElementExists(CheckoutButtonLocator);

        public CartPage(IWebDriver driver) : base(driver)
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
                return  PageName.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
