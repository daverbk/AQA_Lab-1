using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class CartPage : BasePage
    {
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By CheckoutButtonLocator = By.Id("checkout");
        
        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement CheckoutButton => WaitService.WaitUntilElementExists(CheckoutButtonLocator);

        public CartPage(IWebDriver driver) : base(driver)
        {
        }
        
        protected override By GetPageIdentifier()
        {
            return CheckoutButtonLocator;
        }
    }
}
