using NUnit.Framework;
using PageObjectHomework.Pages;
using PageObjectHomework.Services;

namespace PageObjectHomework.Tests
{
    public class EndToEndTest : BaseTest
    {
        private const string RemoveButtonClassValue = "btn btn_secondary btn_small btn_inventory";
    
        [Test]
        [Category("EndToEnd")]
        public void EndToEnd_StandardUser()
        {
            var loginPage = new LoginPage(Driver, true);
            
            loginPage.UserNameInput.SendKeys(Configurator.Username);
            loginPage.PasswordInput.SendKeys(Configurator.Password);
            loginPage.LoginButton.Click();

            var productsPage = new ProductsPage(Driver, false);
            Assert.AreEqual("PRODUCTS", productsPage.PageName.Text);

            productsPage.FirstGoodAddToCartButton.Click();
            Assert.AreEqual(RemoveButtonClassValue, productsPage.FirstGoodAddToCartButton.GetAttribute("class"));
            productsPage.CartButton.Click();

            var cartPage = new CartPage(Driver, false);
            Assert.AreEqual("YOUR CART", cartPage.PageName.Text);
            
            cartPage.CheckoutButton.Click();

            var checkoutStepOnePage = new CheckoutStepOnePage(Driver, false);
            Assert.AreEqual("CHECKOUT: YOUR INFORMATION", checkoutStepOnePage.PageName.Text);
            
            checkoutStepOnePage.FirstNameTextBox.SendKeys("Dave");
            checkoutStepOnePage.LastNameTextBox.SendKeys("Davidson");
            checkoutStepOnePage.PostalCodeTextBox.SendKeys("28031");
            checkoutStepOnePage.ContinueButton.Click();

            var checkoutStepTwoPage = new CheckoutStepTwoPage(Driver, false);
            Assert.AreEqual("CHECKOUT: OVERVIEW", checkoutStepTwoPage.PageName.Text);
            
            checkoutStepTwoPage.FinishButton.Click();

            var checkoutCompletePage = new CheckoutCompletePage(Driver, false);
            Assert.AreEqual("CHECKOUT: COMPLETE!", checkoutCompletePage.PageName.Text);

            checkoutCompletePage.BackHomeButton.Click();
            
            Assert.AreEqual("PRODUCTS", productsPage.PageName.Text);
        }
    }
}
