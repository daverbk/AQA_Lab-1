using NUnit.Framework;
using WrappersHomework.Pages;

namespace WrappersHomework.Tests
{
    public class TableTest : BaseTest
    {
        [Test]
        public void CellSearch()
        {
            var tablePage = new TablePage(Driver);
            tablePage.NavigateToPageAndWaitUntilOpened();

            var cellElement = tablePage.Table.GetCellElement("Sit", "Iuvaret9");
            Assert.AreEqual("Definiebas9", cellElement.Text);

            tablePage.Table.GetElementFromActionsCells("Iuvaret9", "edit").Click();
            Assert.AreEqual(@"https://the-internet.herokuapp.com/challenging_dom#edit", Driver.Url);
        }
    }
}
