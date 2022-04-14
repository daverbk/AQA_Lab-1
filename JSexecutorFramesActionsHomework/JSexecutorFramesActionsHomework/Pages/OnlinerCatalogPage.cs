using System;
using JSexecutorFramesActionsHomework.Services;
using OpenQA.Selenium;

namespace JSexecutorFramesActionsHomework.Pages
{
    public class OnlinerCatalogPage : BasePage
    {
        private const string Endpoint = "/";
            
        private static readonly By CatalogTitleLocator = By.CssSelector(".catalog-navigation__title");
        private static readonly By SearchBarLocator = By.CssSelector("[name = 'query']");
        private static readonly By SearchResultsFrameLocator = By.CssSelector(".modal-iframe");
        private static readonly By FirstResultItemLocator = By.CssSelector(".result__item .product__details .product__title-link");
        private static readonly By InFrameSearchBarLocator = By.CssSelector(".search__input");

        public IWebElement CatalogTitle => WaitService.WaitUntilElementExists(CatalogTitleLocator);
        public IWebElement SearchBar => WaitService.WaitUntilElementExists(SearchBarLocator);
        public IWebElement SearchResultsFrame => WaitService.WaitUntilElementExists(SearchResultsFrameLocator);
        public IWebElement FirstResultItem => WaitService.WaitUntilElementExists(FirstResultItemLocator);
        public IWebElement InFrameSearchBar => WaitService.WaitUntilElementExists(InFrameSearchBarLocator);
        
        public OnlinerCatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.Url + Endpoint);
        }

        protected override bool IsPageOpened()
        {
            try
            {
                return CatalogTitle.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
