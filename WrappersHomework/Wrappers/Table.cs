using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace WrappersHomework.Wrappers
{
    public class Table
    {
        private BaseElementWrapper _baseElementWrapper;
        private IWebDriver _driver;
        private IJavaScriptExecutor _javaScriptExecutor;

        private const int FirstElementIndex = 0;
        
        public bool Displayed => _baseElementWrapper.Displayed;
    
        private ReadOnlyCollection<IWebElement> Headers => _baseElementWrapper.FindElements(By.TagName("th"));
    
        private ReadOnlyCollection<IWebElement> Rows => _baseElementWrapper.FindElements(By.CssSelector("tbody > tr"));

        public Table(IWebDriver driver, By @by)
        {
            _baseElementWrapper = new BaseElementWrapper(driver, by);
            _driver = driver;
            _javaScriptExecutor = (IJavaScriptExecutor) driver;
        }

        public IWebElement GetDeleteEditElement(string rowName, string actionType)
        {
            var cellWithAction = GetCellElement("Action", rowName);
            
            return cellWithAction.FindElement(By.XPath($"//*[text() = '{actionType}']"));
        }
        
        public IWebElement GetCellElement(string columnName, string rowName)
        {
            if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(rowName))
            {
                throw new ArgumentException("Arguments can't be null.");
            }
            
            var targetColumn = _baseElementWrapper.FindElement(By.XPath($"//*[text() = '{columnName}']"));
            var cellIndex = Headers.IndexOf(targetColumn);
            
            var cellElement = _javaScriptExecutor.ExecuteScript(
                "for (let index = 0; index < arguments[0].length; index++) {" + 
                "if (arguments[0][index].cells[arguments[1]].innerText == arguments[2]) {" +
                "return arguments[0][index].cells[arguments[3]];}" +
                "}" , Rows, FirstElementIndex, rowName, cellIndex);

            if (cellElement == null)
            {
                throw new NotFoundException("The cell wasn't found. Check column and row names.");
            }

            return (IWebElement)cellElement;
        }
    }
}
