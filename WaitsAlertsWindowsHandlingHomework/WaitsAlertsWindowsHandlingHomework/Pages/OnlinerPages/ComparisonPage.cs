using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandlingHomework.Services;

namespace WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages
{
    public class ComparisonPage : BasePage
    {
        private const string Endpoint = "/compare";

        private static readonly By ScreenDiagonalLocator = By.XPath("// * [contains(text(), 'Диагональ экрана')]");
        private static readonly By DataTipButtonLocator = By.CssSelector("[data-tip-term = 'Диагональ экрана']");
        private static readonly By DataTipWindowLocator = By.CssSelector(".product-table-tip__content");
        private static readonly By FirstTvDeleteButtonLocator = By.XPath("(//*[@class='product-summary']/ following-sibling :: a) [1]");
        private static readonly By TvsLeftLocator = By.CssSelector(".product-summary");
        
        public IWebElement ScreenDiagonal => WaitService.WaitUntilElementExists(ScreenDiagonalLocator);
        public IWebElement DataTipButton => WaitService.WaitFastElement(DataTipButtonLocator);
        public IWebElement DataTipWindow => WaitService.WaitUntilElementVisible(DataTipWindowLocator);
        public bool IsDataTipWindowInvisible => WaitService.WaitUntilElementInvisible(DataTipWindowLocator);
        public IWebElement FirstTvDeleteButton => WaitService.WaitUntilElementExists(FirstTvDeleteButtonLocator);
        public ReadOnlyCollection<IWebElement> TvsLeft => WaitService.WaitUntilElementsPresent(TvsLeftLocator);
        
        public ComparisonPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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
                return ScreenDiagonal.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
