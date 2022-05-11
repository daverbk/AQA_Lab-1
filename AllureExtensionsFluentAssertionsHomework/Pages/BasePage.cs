using AllureExtensionsFluentAssertionsHomework.Services;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public abstract class BasePage
    {
        private IWebDriver Driver { get; }
        
        protected static WaitService WaitService { get; private set; }

        public bool PageOpened => WaitService.WaitUntilElementExists(GetPageIdentifier()).Displayed;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);
        }

        protected abstract By GetPageIdentifier();
    }
}
