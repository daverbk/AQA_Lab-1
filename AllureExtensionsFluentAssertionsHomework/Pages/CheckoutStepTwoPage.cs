using System;
using AllureExtensionsFluentAssertionsHomework.Services;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        private const string Endpoint = "checkout-step-two.html/";
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By FinishButtonLocator = By.Id("finish");
        
        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement FinishButton => WaitService.WaitUntilElementExists(FinishButtonLocator);
        
        public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
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
    }
}
