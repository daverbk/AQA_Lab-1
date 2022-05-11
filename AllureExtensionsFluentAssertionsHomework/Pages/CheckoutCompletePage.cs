using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By BackHomeButtonLocator = By.Id("back-to-products");

        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement BackHomeButton => WaitService.WaitUntilElementExists(BackHomeButtonLocator);

        public CheckoutCompletePage(IWebDriver driver) : base(driver)
        {
        }

        protected override By GetPageIdentifier()
        {
            return BackHomeButtonLocator;
        }
    }
}
