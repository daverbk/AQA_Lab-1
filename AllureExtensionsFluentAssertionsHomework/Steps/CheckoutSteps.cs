using Allure.Commons;
using AllureExtensionsFluentAssertionsHomework.Pages;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Steps
{
    public class CheckoutSteps : BaseStep
    {
        public CheckoutSteps(IWebDriver driver) : base(driver)
        {
        }
        
        public CheckoutStepOnePage GoToCheckoutStepOne()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CartPage.CheckoutButton.Click();
            }, "Go to Checkout step one");
            
            return CheckoutStepOnePage;
        }
        
        public CheckoutStepTwoPage PopulatePostData(string firstName, string lastName, string postalCode)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CheckoutStepOnePage.FirstNameTextBox.SendKeys(firstName);
                CheckoutStepOnePage.LastNameTextBox.SendKeys(lastName);
                CheckoutStepOnePage.PostalCodeTextBox.SendKeys(postalCode);
                CheckoutStepOnePage.ContinueButton.Click();
            }, $"Insert post information First name: {firstName} Last name: {lastName} Postal code: {postalCode}");

            return CheckoutStepTwoPage;
        }

        public CheckoutCompletePage GoToCheckoutComplete()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CheckoutStepTwoPage.FinishButton.Click();
            }, "Go to Checkout step two");

            return CheckoutCompletePage;
        }

        public ProductsPage GoBackToProductsPage()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CheckoutCompletePage.BackHomeButton.Click();
            }, "Go back to Products page");

            return ProductsPage;
        }
    }
}
