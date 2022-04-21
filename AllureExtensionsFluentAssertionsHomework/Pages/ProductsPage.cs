using System;
using AllureExtensionsFluentAssertionsHomework.Services;
using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class ProductsPage : BasePage
    {
        private const string Endpoint = "inventory.html/";   
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By FirstGoodAddToChartButtonLocator = By.XPath("(//div[@class = 'pricebar']//button)[1]");
        private static readonly By CartButtonLocator = By.ClassName("shopping_cart_link");

        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement FirstGoodAddToCartButton => WaitService.WaitUntilElementExists(FirstGoodAddToChartButtonLocator);
        public IWebElement CartButton => WaitService.WaitUntilElementExists(CartButtonLocator);

        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.BaseUrl + Endpoint);
        }

        protected override bool IsPageOpened()
        {
            try
            {
                return FirstGoodAddToCartButton.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
