using System;
using OpenQA.Selenium;
using PageObjectHomework.Services;

namespace PageObjectHomework.Pages
{
    public class CartPage : BasePage
    {
        private const string Endpoint = "cart.html/";
        
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By GoodsQuantityLocator = By.ClassName("cart_quantity");
        private static readonly By CheckoutButtonLocator = By.Id("checkout");
        
        public CartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
                return  PageName.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IWebElement PageName => Driver.FindElement(PageNameLocator);
        public IWebElement GoodsQuantity => Driver.FindElement(GoodsQuantityLocator);
        public IWebElement CheckoutButton => Driver.FindElement(CheckoutButtonLocator);
    }
}
