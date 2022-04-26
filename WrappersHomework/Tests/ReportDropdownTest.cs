using NUnit.Framework;
using WrappersHomework.Pages;
using WrappersHomework.Services.Configuration;

namespace WrappersHomework.Tests
{
    public class ReportDropdownTest : BaseTest
    {
        [Test]
        public void ReportDropDownTest()
        {
            var testRailCasesPage = new TestRailCasesPage(Driver);
            var testRailLoginPage = new TestRailLogInPage(Driver);
        
            testRailCasesPage.NavigateToPage();
            testRailLoginPage.CheckIfPageOpened();
        
            testRailLoginPage.LoginFiled.SendKeys(Users.Email);
            testRailLoginPage.PasswordFiled.SendKeys(Users.Password);
            testRailLoginPage.LogInButton.Click();

            testRailCasesPage.CheckIfPageOpened();
        
            testRailCasesPage.DropDown.OpenDropDown();
            Assert.IsTrue(testRailCasesPage.DropDown.Displayed);
        
            testRailCasesPage.DropDown.CloseDropDown();
            Assert.IsFalse(testRailCasesPage.DropDown.Displayed);
        
            testRailCasesPage.DropDown.OpenDropDown();
            testRailCasesPage.DropDown.GetDropDownOption("Summary for Cases").Click();
            // DEVNOTE: Show must go on ...
        }
    }
}
