using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By FinishButtonLocator = By.Id("finish");
        
        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement FinishButton => WaitService.WaitUntilElementExists(FinishButtonLocator);
        
        public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
        {
        }

        protected override By GetPageIdentifier()
        {
            return FinishButtonLocator;
        }
    }
}
