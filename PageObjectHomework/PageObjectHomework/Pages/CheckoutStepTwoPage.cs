using System;
using OpenQA.Selenium;
using PageObjectHomework.Services;

namespace PageObjectHomework.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        private const string Endpoint = "checkout-step-two.html/";
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By FinishButtonLocator = By.Id("finish");
        
        public CheckoutStepTwoPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
                return  FinishButton.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public IWebElement PageName => Driver.FindElement(PageNameLocator);
        public IWebElement FinishButton => Driver.FindElement(FinishButtonLocator);
    }
}
