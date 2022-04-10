using System;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandlingHomework.Services;

namespace WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages
{
    public class TvCatalogPage : BasePage
    {
        private const string Endpoint = "/tv";

        private static readonly By FirstDivFirstTvCheckLocator = By.XPath("(( //div[@class='schema-product__group']) [1]// label) [1]");
        private static readonly By SecondDivFirstTvCheckLocator = By.XPath("(( //div[@class='schema-product__group']) [2]// label) [1]");
        private static readonly By ComparisonButtonLocator = By.CssSelector(".compare-button__sub_main");
        private static readonly By VkFooterLinkLocator = By.CssSelector(".footer-style__social-button_vk");
        private static readonly By FbFooterLinkLocator = By.CssSelector(".footer-style__social-button_fb");
        private static readonly By TwFooterLinkLocator = By.CssSelector(".footer-style__social-button_tw");
        
        public IWebElement FirstDivFirstTvCheck => WaitService.WaitUntilElementExists(FirstDivFirstTvCheckLocator);
        public IWebElement SecondDivFirstTvCheck => WaitService.WaitUntilElementExists(SecondDivFirstTvCheckLocator);
        public IWebElement ComparisonButton => WaitService.WaitUntilElementExists(ComparisonButtonLocator);
        public IWebElement VkFooterLink => WaitService.WaitUntilElementExists(VkFooterLinkLocator);
        public IWebElement FbFooterLink => WaitService.WaitUntilElementExists(FbFooterLinkLocator);
        public IWebElement TwFooterLink => WaitService.WaitUntilElementExists(TwFooterLinkLocator);
        
        public TvCatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.OnlinerBaseUrl + Endpoint);
        }

        protected override bool IsPageOpened()
        {
            try
            {
                return FirstDivFirstTvCheck.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
