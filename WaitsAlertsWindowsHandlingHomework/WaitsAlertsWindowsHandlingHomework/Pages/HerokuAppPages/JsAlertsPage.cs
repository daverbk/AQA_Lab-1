using System;
using OpenQA.Selenium;
using WaitsAlertsWindowsHandlingHomework.Services;

namespace WaitsAlertsWindowsHandlingHomework.Pages.HerokuAppPages
{
    public class JsAlertsPage : BasePage
    {
        private const string Endpoint = "/javascript_alerts";

        private static readonly By ClickForJsAlertLocator = By.CssSelector("li:nth-child(1) > button");
        private static readonly By ClickForJsConfirmLocator = By.CssSelector("li:nth-child(2) > button");
        private static readonly By ClickForJsPromptLocator = By.CssSelector("li:nth-child(3) > button");
        private static readonly By ResultLocator = By.Id("result");
        
        public IWebElement ClickForJsAlert => WaitService.WaitUntilElementExists(ClickForJsAlertLocator);
        public IWebElement ClickForJsConfirm => WaitService.WaitUntilElementExists(ClickForJsConfirmLocator);
        public IWebElement ClickForJsPrompt => WaitService.WaitUntilElementExists(ClickForJsPromptLocator);
        public IWebElement Result => WaitService.WaitUntilElementExists(ResultLocator);
        
        public JsAlertsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        
        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(Configurator.HerokuAppBaseUrl + Endpoint);
        }

        protected override bool IsPageOpened()
        {
            try
            {
                return ClickForJsAlert.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
