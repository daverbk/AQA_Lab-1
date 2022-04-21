using Allure.Commons;
using AllureExtensionsFluentAssertionsHomework.Extensions;
using FluentAssertions;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Steps
{
    public class StandardUserSteps : BaseStep
    {
        private const string RemoveButtonClassValue = "btn btn_secondary btn_small btn_inventory";

        public StandardUserSteps(IWebDriver driver) : base(driver)
        {
        }
        
        public void InsertUserNameAndPassword(string login, string password)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                LoginPage.OpenAndWait();
                LoginPage.UserNameInput.SendKeys(login);
                LoginPage.PasswordInput.SendKeys(password);
                LoginPage.LoginButton.Click();
            }, $"Insert username: {login} and password: {password}");
        }

        public void CheckProductsPageOpened()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                ProductsPage.WaitUntilOpened();
                ProductsPage.PageName.Text.IsEqualTo("PRODUCTS").Should().BeTrue();
            }, "Check Products page is opened");
        }

        public void SelectItemAndCheckButtonChange()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                ProductsPage.FirstGoodAddToCartButton.Click();
                ProductsPage.FirstGoodAddToCartButton.GetAttribute("class").Should().Be(RemoveButtonClassValue);
            }, "SelectAnItemAndCheckButtonChange");
        }

        public void GoToCartCheckIfOpens()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                ProductsPage.CartButton.Click();
                CartPage.WaitUntilOpened();
                CartPage.PageName.Text.IsEqualTo("YOUR CART").Should().BeTrue();
            }, "Go to Cart page");
        }

        public void GoToCheckoutStepOneCheckIfOpens()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CartPage.CheckoutButton.Click();
                CheckoutStepOnePage.WaitUntilOpened();
                CheckoutStepOnePage.PageName.Text.IsEqualTo("CHECKOUT: YOUR INFORMATION").Should().BeTrue();
            }, "Go to Checkout step one");
        }

        public void InsertPostInformation(string firstName, string lastName, string postalCode)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CheckoutStepOnePage.FirstNameTextBox.SendKeys(firstName);
                CheckoutStepOnePage.LastNameTextBox.SendKeys(lastName);
                CheckoutStepOnePage.PostalCodeTextBox.SendKeys(postalCode);
            }, $"Insert post information First name: {firstName} Last name: {lastName} Postal code: {postalCode}");
        }

        public void GoToCheckoutStepTwoCheckIfOpens()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CheckoutStepOnePage.ContinueButton.Click();
                CheckoutStepTwoPage.WaitUntilOpened();
                CheckoutStepTwoPage.PageName.Text.IsEqualTo("CHECKOUT: OVERVIEW").Should().BeTrue();
            }, "Go to Checkout step two");
        }
        
        public void GoToCheckoutCompleteCheckIfOpens()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CheckoutStepTwoPage.FinishButton.Click();
                CheckoutCompletePage.WaitUntilOpened();
                CheckoutCompletePage.PageName.Text.IsEqualTo("CHECKOUT: COMPLETE!").Should().BeTrue();
            }, "Go to Checkout step two");
        }

        public void GoBackToProductsPageCheckIfOpens()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                CheckoutCompletePage.BackHomeButton.Click();
                ProductsPage.PageName.Text.IsEqualTo("PRODUCTS").Should().BeTrue();
            }, "Go back to Products page");
        }
    }
}
