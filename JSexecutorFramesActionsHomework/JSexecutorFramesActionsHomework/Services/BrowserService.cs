using System;
using OpenQA.Selenium;

namespace JSexecutorFramesActionsHomework.Services
{
    public class BrowserService
    {
        private IWebDriver _driver;
        
        public IWebDriver Driver
        {
            get => _driver;
            set => _driver = value;
        }

        public BrowserService()
        {
            Driver = Configurator.BrowserType.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };
            
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
