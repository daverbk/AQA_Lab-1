using NLog;
using NUnit.Framework;
using WaitsAlertsWindowsHandlingHomework.Pages.HerokuAppPages;

namespace WaitsAlertsWindowsHandlingHomework.Tests
{
    public class AlertsTest : BaseTest
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        [Test]
        public void HerokuAlertsTest()
        {
            var jsAlertPage = new JsAlertsPage(Driver, true);

            jsAlertPage.ClickForJsAlert.Click();
            var simpleAlert = Driver.SwitchTo().Alert();
            _logger.Info("{alertText}", simpleAlert.Text);
            simpleAlert.Accept();
            
            jsAlertPage.ClickForJsConfirm.Click();
            var confirmationAlertOne = Driver.SwitchTo().Alert();
            _logger.Info("{alertText}", confirmationAlertOne.Text);
            confirmationAlertOne.Accept();
            
            jsAlertPage.ClickForJsConfirm.Click();
            var confirmationAlertTwo = Driver.SwitchTo().Alert();
            confirmationAlertTwo.Dismiss();
            
            jsAlertPage.ClickForJsPrompt.Click();
            var promptAlert = Driver.SwitchTo().Alert();
            _logger.Info("{alertText}", promptAlert.Text);
            promptAlert.SendKeys("Great site");
            promptAlert.Accept();

            _logger.Info("{resultText}", jsAlertPage.Result.Text);
        }
    }
}
