using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages;


namespace WaitsAlertsWindowsHandlingHomework.Tests
{
    public class WaitTest : BaseTest
    {
        private Actions _actions;

        [Test]
        public void OnlinerWaitTest()
        {
            var tvCatalogPage = new TvCatalogPage(Driver, true);
            
            tvCatalogPage.FirstDivFirstTvCheck.Click();
            tvCatalogPage.SecondDivFirstTvCheck.Click();
            tvCatalogPage.ComparisonButton.Click();

            var comparisonPage = new ComparisonPage(Driver, false);
            
            _actions = new Actions(Driver);
            _actions.MoveToElement(comparisonPage.ScreenDiagonal).Perform();
            comparisonPage.DataTipButton.Click();

            Assert.IsTrue(comparisonPage.DataTipWindow.Displayed);
            
            comparisonPage.DataTipButton.Click();
            
            Assert.IsTrue(comparisonPage.IsDataTipWindowInvisible);
            
            comparisonPage.FirstTvDeleteButton.Click();
            
            Assert.AreEqual(2, comparisonPage.TvsLeft.Count);
        }
    }
}
