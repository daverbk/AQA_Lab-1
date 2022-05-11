using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class CheckoutStepOnePage : BasePage
    {
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By ContinueButtonLocator = By.Id("continue");
        private static readonly By FirstNameTextBoxLocator = By.Id("first-name");
        private static readonly By LastNameTextBoxLocator = By.Id("last-name");
        private static readonly By PostalCodeTextBoxLocator = By.Id("postal-code");
        
        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement ContinueButton => WaitService.WaitUntilElementExists(ContinueButtonLocator);
        public IWebElement FirstNameTextBox => WaitService.WaitUntilElementExists(FirstNameTextBoxLocator);
        public IWebElement LastNameTextBox => WaitService.WaitUntilElementExists(LastNameTextBoxLocator);
        public IWebElement PostalCodeTextBox => WaitService.WaitUntilElementExists(PostalCodeTextBoxLocator);
        
        public CheckoutStepOnePage(IWebDriver driver) : base(driver)
        {
        }

        protected override By GetPageIdentifier()
        {
            return ContinueButtonLocator;
        }
    }
}
