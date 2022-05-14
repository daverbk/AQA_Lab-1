using BDDHomework.Configuration;
using OpenQA.Selenium;

namespace BDDHomework.Services.SeleniumServices
{
    public class BrowserService
    {
        private IWebDriver _driver = null!;
        
        public IWebDriver Driver
        {
            get => _driver;
            set => _driver = value;
        }

        public BrowserService()
        {
            Driver = Configurator.AppSettings.BrowserType.ToLower() switch
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
