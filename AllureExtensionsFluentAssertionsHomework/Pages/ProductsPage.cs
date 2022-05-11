using OpenQA.Selenium;

namespace AllureExtensionsFluentAssertionsHomework.Pages
{
    public class ProductsPage : BasePage
    {
        private static readonly By PageNameLocator = By.CssSelector("span[class = 'title']");
        private static readonly By CartButtonLocator = By.ClassName("shopping_cart_link");

        private static By ItemAddToChartButtonLocator(int productNumber = 1) => By.XPath($"(//div[@class = 'pricebar']//button)[{productNumber}]");
        public IWebElement ProductAddToCartButton(int productNumber) => WaitService.WaitUntilElementClickable(ItemAddToChartButtonLocator(productNumber));
        
        public IWebElement PageName => WaitService.WaitUntilElementExists(PageNameLocator);
        public IWebElement CartButton => WaitService.WaitUntilElementExists(CartButtonLocator);

        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        protected override By GetPageIdentifier()
        {
            return ItemAddToChartButtonLocator();
        }
    }
}
