using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using WrappersHomework.Services;

namespace WrappersHomework.Wrappers
{
    public class BaseElementWrapper : IWebElement
    {
        private readonly By _locator;
        private readonly IWebDriver _driver;
        private readonly WaitService _waitService;
        private readonly IWebElement _webElement;
        
        public string TagName => _webElement.TagName;
    
        public string Text => _webElement.Text;
    
        public bool Enabled => _webElement.Enabled;
    
        public bool Selected => _webElement.Selected;
    
        public Point Location => _webElement.Location;
    
        public Size Size => _webElement.Size;

        public bool Displayed => _webElement.Displayed;

        public BaseElementWrapper(IWebDriver driver, By locator)
        {
            _driver = driver;
            _locator = locator;
            _waitService = new WaitService(_driver);
            _webElement = _waitService.WaitUntilElementExists(_locator);
        }
    
        public IWebElement FindElement(By @by)
        {
            return _webElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _webElement.FindElements(by);
        }

        public void Clear()
        {
            _webElement.Clear();
        }

        public void SendKeys(string text)
        {
            _waitService.WaitElementClickable(_webElement).SendKeys(text);
        }

        public void Submit()
        {
            _webElement.Submit();
        }

        public void Click()
        {
            _waitService.WaitElementClickable(_webElement).Click();
        }

        public string GetAttribute(string attributeName)
        {
            return _webElement.GetAttribute(attributeName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return _webElement.GetDomAttribute(attributeName);
        }

        public string GetProperty(string propertyName)
        {
            return _webElement.GetProperty(propertyName);
        }

        public string GetDomProperty(string propertyName)
        {
            return _webElement.GetDomProperty(propertyName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElement.GetCssValue(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            return _webElement.GetShadowRoot();
        }
    }
}
