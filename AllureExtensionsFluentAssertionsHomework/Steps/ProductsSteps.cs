using Allure.Commons;
using AllureExtensionsFluentAssertionsHomework.Pages;
using NUnit.Allure.Core;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Steps
{
    public class ProductsSteps : BaseStep
    {
        public ProductsSteps(IWebDriver driver) : base(driver)
        {
        }

        public string SelectProduct(int productNumber)
        {
            return AllureLifecycle.Instance.WrapInStep(() =>
            {
                var chosenProductAddToCartButton = ProductsPage.ProductAddToCartButton(productNumber);
                chosenProductAddToCartButton.Click();
                
                return ProductsPage.ProductAddToCartButton(productNumber).GetAttribute("class");
            }, $"Select product number {productNumber}");
        }

        public CartPage GoToCart()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                ProductsPage.CartButton.Click();
            }, "Go to cart page");

            return CartPage;
        }
    }
}
