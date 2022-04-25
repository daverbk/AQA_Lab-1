using System;
using OpenQA.Selenium;

namespace WrappersHomework.Wrappers
{
    public class CheckBox
    {
        private readonly BaseElementWrapper _baseElementWrapper;

        public bool Displayed => _baseElementWrapper.Displayed;
        
        public bool IsChecked
        {
            get
            {
                var selectedCheckBoxAttribute = _baseElementWrapper.GetAttribute("checked");

                return selectedCheckBoxAttribute is not null;
            }
        }
        
        public CheckBox(IWebDriver driver, By locator)
        {
            _baseElementWrapper = new BaseElementWrapper(driver, locator);
        }

        public void Check()
        {
            if (!IsChecked)
            {
                _baseElementWrapper.Click();
            }
            else
            {
                throw new InvalidOperationException("The checkbox is already checked.");
            }
        }
        
        public void Uncheck()
        {
            if (IsChecked)
            {
                _baseElementWrapper.Click();
            }
            else
            {
                throw new InvalidOperationException("The checkbox is already unchecked.");
            }
        }
    }
}
