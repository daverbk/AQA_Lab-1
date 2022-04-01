using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LocatorsHomework
{
    public class Tests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(Endpoits.FullPathToIndex);
        }

        [Test]
        public void TestXpathSelectors()
        {
            Assert.Multiple(() =>
            {
                // Отобразить второй элемент содержащий текст 'Test'
                Assert.IsTrue(_driver.FindElement(By.XPath("(//*[contains(text(),'Test')])[2]")).Displayed);

                // Отобразить элемент, текст в котором равен 'Test' и атрибут равный 'ids'
                Assert.IsTrue(_driver.FindElement(By.XPath("//*[text() ='Test'][@ids]")).Displayed);

                // Отобрать элемент с текстом 'Title 2'
                Assert.IsTrue(_driver.FindElement(By.XPath("//*[normalize-space() ='Title 2']")).Displayed);

                // Отобрать элемент h1 который содержит элемент с текстом 'Title 3'
                Assert.IsTrue(_driver.FindElement(By.XPath("//*[normalize-space() ='Title 3']/ancestor::h1"))
                    .Displayed);

                // Отобрать второй элемент класса 'arrow' из блока в котором присутствует текст 'Title 2' 
                Assert.IsTrue(_driver
                    .FindElement(
                        By.XPath("(//*[normalize-space() ='Title 2']/ancestor :: div//*[@class = 'arrow'])[2]"))
                    .Displayed);
            });
        }
        
        [Test]
        public void TestCssSelectors()
        {
            Assert.Multiple(() =>
            {
                // Отобразить элемент с текстом 'Locator'
                Assert.IsTrue(_driver.FindElement(By.CssSelector("span[id='123']")).Displayed);
                
                // Отобразить элемент с id = '123'
                Assert.IsTrue(_driver.FindElement(By.CssSelector("[id='123']")).Displayed);
                
                // Отобрать элементы с классом 'arrow'
                Assert.AreEqual(6, _driver.FindElements(By.CssSelector(".arrow")).Count);
                
                // Отобрать все элементы <span> у которых родителями является <h1>
                Assert.AreEqual(3, _driver.FindElements(By.CssSelector("h1 > span")).Count);
                // At the same time if we would like to find all of the children (grandchildren included)  
                Assert.AreEqual(6, _driver.FindElements(By.CssSelector("h1 span")).Count);
                
                // Отобрать все элементы <span> у которых параметр value начинается с '12'
                Assert.AreEqual(2, _driver.FindElements(By.CssSelector("span[value^='12']")).Count);
            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
    }
}
