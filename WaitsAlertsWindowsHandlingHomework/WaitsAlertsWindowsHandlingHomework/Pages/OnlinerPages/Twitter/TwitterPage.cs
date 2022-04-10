using System;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandlingHomework.Services;

namespace WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages.Twitter
{
    public class TwitterPage : BasePage
    {
        private const string Endpoint = "/OnlinerBY";
        
        private static readonly By TwitterLogoLocator = By.CssSelector("h1[role = 'heading']");
        private static readonly By ExploreButtonLocator = By.CssSelector("[href = '/explore']");
        private static readonly By MainOnlinerTitleLocator = By.XPath("(//span[contains(text(), 'onlíner')]) [1]");
        
        public IWebElement TwitterLogo => WaitService.WaitUntilElementExists(TwitterLogoLocator);
        public IWebElement ExploreButton => WaitService.WaitUntilElementExists(ExploreButtonLocator);
        public IWebElement MainOnlinerTitle => WaitService.WaitUntilElementExists(MainOnlinerTitleLocator);
        
        public TwitterPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.TwitterBaseUrl + Endpoint);
        }

        protected override bool IsPageOpened()
        {
            try
            {
                return TwitterLogo.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
