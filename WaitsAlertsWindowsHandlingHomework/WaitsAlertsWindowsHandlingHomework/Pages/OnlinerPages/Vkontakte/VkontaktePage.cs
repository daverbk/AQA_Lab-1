using System;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandlingHomework.Services;

namespace WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages.Vkontakte
{
    public class VkontaktePage : BasePage
    {
        private const string Endpoint = "/onliner";

        private static readonly By VkHeaderLocator = By.CssSelector("svg[width = '30'][height = '30'] path:nth-child(1)");
        private static readonly By VkSignInButtonLocator = By.CssSelector(".quick_login_button");
        private static readonly By OnlinerTitleLocator = By.XPath("//h1[contains(text(), 'onlíner')]");

        public IWebElement VkHeader => WaitService.WaitUntilElementExists(VkHeaderLocator);
        public IWebElement VkSignInButton => WaitService.WaitUntilElementExists(VkSignInButtonLocator);
        public IWebElement OnlinerTitle => WaitService.WaitUntilElementExists(OnlinerTitleLocator);


        public VkontaktePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.VkontakteBaseUrl + Endpoint);
        }

        protected override bool IsPageOpened()
        {
            try
            {
                return VkHeader.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
