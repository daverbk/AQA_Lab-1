using System;
using OpenQA.Selenium;
using PageObjectHomework.Services;

namespace PageObjectHomework.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private const string Endpoint = "checkout-complete.html/";
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By BackHomeButtonLocator = By.Id("back-to-products");

        public CheckoutCompletePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
        
        public IWebElement PageName => Driver.FindElement(PageNameLocator);
        public IWebElement BackHomeButton => Driver.FindElement(BackHomeButtonLocator);
    }
}
