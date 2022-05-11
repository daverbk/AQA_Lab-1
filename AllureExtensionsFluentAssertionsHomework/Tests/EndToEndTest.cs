using Allure.Commons;
using AllureExtensionsFluentAssertionsHomework.Extensions;
using AllureExtensionsFluentAssertionsHomework.Services;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AllureExtensionsFluentAssertionsHomework.Tests
{
    [AllureNUnit]
    [AllureStory]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureTag("E2E Critical path")]
    [AllureLabel("Priority", "High")]
    [AllureSuite("E2E SauceDemo")]
    [AllureOwner("David Ryabko")]
    public class EndToEndTest : BaseTest
    {
        private const string ExpectedProductsPageTitle = "PRODUCTS";
        private const string ExpectedCartPageTitle = "YOUR CART";
        private const string ExpectedCheckoutStepOnePageTitle = "CHECKOUT: YOUR INFORMATION";
        private const string ExpectedCheckoutStepTwoPageTitle = "CHECKOUT: OVERVIEW";
        private const string ExpectedCheckoutCompletePageTitle = "CHECKOUT: COMPLETE!";

        private const int ProductToChooseNumber = 1;
        private const string RemoveButtonClassValue = "btn btn_secondary btn_small btn_inventory";

        [Test]
        [Category("EndToEnd")]
        public void EndToEnd_StandardUser()
        {
            var productsPage = LoginSteps.InsertUserNameAndPassword(Configurator.UserName, Configurator.Password);
            productsPage.PageOpened.Should().BeTrue();
            productsPage.PageName.Text.IsEqualTo(ExpectedProductsPageTitle).Should().BeTrue();

            var chosenProductAddToCartButtonNewValue = ProductsSteps.SelectProduct(ProductToChooseNumber);
            chosenProductAddToCartButtonNewValue.Should().Be(RemoveButtonClassValue);

            var cartPage = ProductsSteps.GoToCart();
            cartPage.PageOpened.Should().BeTrue();
            cartPage.PageName.Text.IsEqualTo(ExpectedCartPageTitle).Should().BeTrue();

            var checkoutStepOnePage = CheckoutSteps.GoToCheckoutStepOne();
            checkoutStepOnePage.PageOpened.Should().BeTrue();
            checkoutStepOnePage.PageName.Text.IsEqualTo(ExpectedCheckoutStepOnePageTitle).Should().BeTrue();

            var checkoutStepTwoPage = CheckoutSteps.PopulatePostData("Dave", "Davidson", "28031");
            checkoutStepTwoPage.PageOpened.Should().BeTrue();
            checkoutStepTwoPage.PageName.Text.IsEqualTo(ExpectedCheckoutStepTwoPageTitle).Should().BeTrue();

            var checkoutCompletePage = CheckoutSteps.GoToCheckoutComplete();
            checkoutCompletePage.PageOpened.Should().BeTrue();
            checkoutCompletePage.PageName.Text.IsEqualTo(ExpectedCheckoutCompletePageTitle).Should().BeTrue();

            productsPage = CheckoutSteps.GoBackToProductsPage();
            productsPage.PageOpened.Should().BeTrue();
            productsPage.PageName.Text.IsEqualTo(ExpectedProductsPageTitle).Should().BeTrue();
        }
    }
}
