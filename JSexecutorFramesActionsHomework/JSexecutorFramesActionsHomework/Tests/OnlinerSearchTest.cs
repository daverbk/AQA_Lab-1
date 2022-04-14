using JSexecutorFramesActionsHomework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace JSexecutorFramesActionsHomework.Tests
{
    public class OnlinerSearchTest : BaseTest
    {
        private Actions _actions;
        private IJavaScriptExecutor _javaScriptExecutor;
        
        [Test]
        public void OnlinerCatalogSearchTest()
        {
            var onlinerCatalogPage = new OnlinerCatalogPage(Driver, true);

            _javaScriptExecutor = (IJavaScriptExecutor) Driver;
            _javaScriptExecutor.ExecuteScript("arguments[0].click();", onlinerCatalogPage.SearchBar);
            onlinerCatalogPage.SearchBar.SendKeys("Тостер");

            Driver.SwitchTo().Frame(onlinerCatalogPage.SearchResultsFrame);
            var firstResultItemName = onlinerCatalogPage.FirstResultItem.Text;
            
            onlinerCatalogPage.InFrameSearchBar.Clear();
            _actions = new Actions(Driver);
            _actions.SendKeys(onlinerCatalogPage.InFrameSearchBar, firstResultItemName).Perform();;

            Assert.AreEqual(firstResultItemName, onlinerCatalogPage.FirstResultItem.Text);
        }
    }
}
