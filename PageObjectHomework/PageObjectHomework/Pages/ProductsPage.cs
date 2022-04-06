using System;
using OpenQA.Selenium;
using PageObjectHomework.Services;

namespace PageObjectHomework.Pages
{
    public class ProductsPage : BasePage
    {
        private const string Endpoint = "inventory.html/";   
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By FirstGoodAddToChartButtonLocator = By.XPath("(//div[@class = 'pricebar']//button)[1]");
        private static readonly By CartButtonLocator = By.ClassName("shopping_cart_link");

        public ProductsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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

        public IWebElement PageName => Driver.FindElement(PageNameLocator);
        public IWebElement FirstGoodAddToCartButton => Driver.FindElement(FirstGoodAddToChartButtonLocator);
        public IWebElement CartButton => Driver.FindElement(CartButtonLocator);
    }
}
