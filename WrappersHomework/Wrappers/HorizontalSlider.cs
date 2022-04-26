using System;
using OpenQA.Selenium;

namespace WrappersHomework.Wrappers
{
    public class HorizontalSlider
    {
        private readonly BaseElementWrapper _baseElementWrapper;
        private readonly IWebDriver _driver;
        private readonly IJavaScriptExecutor _javaScriptExecutor;

        private const int FirstElementIndex = 0;
        private const decimal StepSizeToRollBackToZero = 5.0m;
        private const decimal DefaultStepSize = 0.5m;
        public const decimal SliderMaxValue = 5.0m;
        public const decimal SliderMinValue = 0.0m;
        
        public bool Displayed => _baseElementWrapper.Displayed;

        private IWebElement SliderValue => _driver.FindElement(By.CssSelector("span[id = 'range']"));
        
        public HorizontalSlider(IWebDriver driver, By @by)
        {
            _baseElementWrapper = new BaseElementWrapper(driver, by);
            _driver = driver;
            _javaScriptExecutor = (IJavaScriptExecutor) driver;
        }

        public void SetSliderToMaxValue()
        {
            if (decimal.Parse(SliderValue.Text.Trim()) != SliderMinValue)
            {   
                SetSliderToMinValue();
            }
            
            SetSliderToValue(SliderMaxValue);
        }
        
        public void SetSliderToValue(decimal valueToSet)
        {
            if (valueToSet is > SliderMaxValue or < SliderMinValue)
            {
                throw new ArgumentException($"Value can't be less than {SliderMinValue} or bigger than {SliderMaxValue}.");
            }

            if (valueToSet % DefaultStepSize != 0)
            {
                throw new ArgumentException($"The only allowed fraction is {DefaultStepSize}.");
            }
            
            if (valueToSet == SliderMinValue)
            {
                SetSliderToMinValue();
                return;
            }
            
            if (decimal.Parse(SliderValue.Text.Trim()) != SliderMinValue)
            {
                SetSliderToMinValue();
            }
            
            _javaScriptExecutor.ExecuteScript(
                $"document.querySelectorAll('input[type = \"range\"]')[{FirstElementIndex}].setAttribute(\"step\", {valueToSet});");
            _baseElementWrapper.SendKeys(Keys.ArrowRight);
        }

        public void SetSliderToMinValue()
        {
            _javaScriptExecutor.ExecuteScript(
                $"document.querySelectorAll('input[type = \"range\"]')[{FirstElementIndex}].setAttribute(\"step\", {StepSizeToRollBackToZero});");
            _baseElementWrapper.SendKeys(Keys.ArrowLeft);
        }
    }
}
