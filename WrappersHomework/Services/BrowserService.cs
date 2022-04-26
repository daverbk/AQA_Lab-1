using System;
using OpenQA.Selenium;
using WrappersHomework.Services.Configuration;

namespace WrappersHomework.Services
{
    public class BrowserService
    {
        public IWebDriver Driver { get; set; }

        public BrowserService()
        {
            Driver = AppSettings.BrowserType switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => null
            };
            
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}
