using AllureExtensionsFluentAssertionsHomework.Pages;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Steps
{
    public class BaseStep
    {
        private IWebDriver _driver;
        
        protected LoginPage LoginPage;
        protected ProductsPage ProductsPage;
        protected CartPage CartPage;
        protected CheckoutStepOnePage CheckoutStepOnePage;
        protected CheckoutStepTwoPage CheckoutStepTwoPage;
        protected CheckoutCompletePage CheckoutCompletePage;

        public BaseStep(IWebDriver driver)
        {
            _driver = driver;
            
            LoginPage = new LoginPage(_driver);
            ProductsPage = new ProductsPage(_driver);
            CartPage = new CartPage(_driver);
            CheckoutStepOnePage = new CheckoutStepOnePage(_driver);
            CheckoutStepTwoPage = new CheckoutStepTwoPage(_driver);
            CheckoutCompletePage = new CheckoutCompletePage(_driver);
        }   
    }
}
