using NUnit.Framework;
using WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages;
using WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages.Facebook;
using WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages.Twitter;
using WaitsAlertsWindowsHandlingHomework.Pages.OnlinerPages.Vkontakte;

namespace WaitsAlertsWindowsHandlingHomework.Tests
{
    public class WindowsHandlingTest : BaseTest
    {
        [Test]
        public void SocialMediaWindowsHandlingTest()
        {
            var tvCatalogPage = new TvCatalogPage(Driver, true);

            tvCatalogPage.VkFooterLink.Click();
            tvCatalogPage.FbFooterLink.Click();
            tvCatalogPage.TwFooterLink.Click();

            var allWindowHandles = Driver.WindowHandles;
            
            Driver.SwitchTo().Window(allWindowHandles[1]);
            var twPage = new TwitterPage(Driver, false);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(twPage.TwitterLogo.Displayed);
                Assert.IsTrue(twPage.MainOnlinerTitle.Text.Contains("onlíner"));
            });
            twPage.ExploreButton.Click();
            
            Driver.SwitchTo().Window(allWindowHandles[2]);
            var fbPage = new FacebookPage(Driver, false);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(fbPage.FacebookHeader.Displayed);
                Assert.IsTrue(fbPage.OnlinerTitle.Text.Contains("onlíner"));
            });
            fbPage.FirstAboutTab.Click();
            
            Driver.SwitchTo().Window(allWindowHandles[3]);
            var vkPage = new VkontaktePage(Driver, false);
            Assert.Multiple(() =>
            {
                Assert.IsTrue(vkPage.VkHeader.Displayed);
                Assert.IsTrue(vkPage.OnlinerTitle.Text.Contains("onlíner"));
            });
            vkPage.VkSignInButton.Click();
        }
    }
}
