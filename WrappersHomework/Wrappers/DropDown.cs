using System;
using OpenQA.Selenium;

namespace WrappersHomework.Wrappers
{
    public class DropDown
    {
        private readonly BaseElementWrapper _baseElementWrapper;
        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _javaScriptExecutor;

        public bool Displayed => _baseElementWrapper.Displayed;

        public DropDown(IWebDriver driver, By locator)
        {
            _baseElementWrapper = new BaseElementWrapper(driver, locator);
            _driver = driver;
            _javaScriptExecutor = (IJavaScriptExecutor)_driver;
        }

        public void OpenDropDown()
        {
            if (!Displayed)
            {
                _javaScriptExecutor.ExecuteScript("document.getElementById('reportDropdown').style.display = \"block\"");
            }
            else
            {
                throw new InvalidOperationException("Drop down is already opened.");
            }
        }

        public IWebElement GetDropDownOption(string dropDownOption)
        {
            IWebElement result;
            
            if (string.IsNullOrEmpty(dropDownOption))
            {
                throw new ArgumentException("Drop down option can't be null.");
            }

            if (Displayed)
            {
                result = _driver.FindElement(By.LinkText(dropDownOption.Trim()));   
            }
            else
            {
                throw new InvalidOperationException("The drop down wasn't opened.");
            }
        
            return result;
        }

        public void CloseDropDown()
        {
            if (Displayed)
            {
                _javaScriptExecutor.ExecuteScript("document.getElementById('reportDropdown').style.display = \"none\"");   
            }
            else
            {
                throw new InvalidOperationException("The drop down is already closed.");
            }
        }
    }
}
