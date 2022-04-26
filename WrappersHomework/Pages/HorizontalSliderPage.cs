using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WrappersHomework.Services.Configuration;
using WrappersHomework.Wrappers;

namespace WrappersHomework.Pages
{
    public class HorizontalSliderPage : BasePage
    {
        private const string Endpoint = "/horizontal_slider";
    
        private static readonly By SliderLocator = By.TagName("input");
        private static readonly By SliderValueLocator = By.CssSelector("#range");

        public HorizontalSlider Slider => new(Driver, SliderLocator);
        public IWebElement SliderValue => WaitService.WaitUntilElementExists(SliderValueLocator);

        public HorizontalSliderPage(IWebDriver driver) : base(driver)
        {
        }

        public override void NavigateToPage()
        {
            Driver.Navigate().GoToUrl(AppSettings.BaseUrl + Endpoint);
        }

        public override bool CheckIfPageOpened()
        {
            try
            {
                return Slider.Displayed;
            }
            catch (TimeoutException)
            {
                throw new AssertionException("The page wasn't opened.");
            }
        }
    }
}
