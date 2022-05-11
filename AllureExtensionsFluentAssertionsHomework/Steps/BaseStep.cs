using AllureExtensionsFluentAssertionsHomework.Pages;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Steps
{
    public class BaseStep
    {
        private IWebDriver _driver;

        protected readonly LoginPage LoginPage;
        protected readonly ProductsPage ProductsPage;
        protected readonly CartPage CartPage;
        protected readonly CheckoutStepOnePage CheckoutStepOnePage;
        protected readonly CheckoutStepTwoPage CheckoutStepTwoPage;
        protected readonly CheckoutCompletePage CheckoutCompletePage;

        protected BaseStep(IWebDriver driver)
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
