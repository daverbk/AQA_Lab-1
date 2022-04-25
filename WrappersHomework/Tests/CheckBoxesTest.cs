using NUnit.Framework;
using WrappersHomework.Pages;

namespace WrappersHomework.Tests
{
    public class CheckBoxesTest : BaseTest
    {
        [Test]
        public void CheckBoxChecks()
        {
            var checkBoxPage = new CheckBoxesPage(Driver);
            checkBoxPage.NavigateToPageAndWaitUntilOpened();
            
            checkBoxPage.FirstCheckBox.Check();
            Assert.IsTrue(checkBoxPage.FirstCheckBox.IsChecked);
        
            checkBoxPage.SecondCheckBox.Uncheck();
            Assert.IsFalse(checkBoxPage.SecondCheckBox.IsChecked);
        }
    }
}
