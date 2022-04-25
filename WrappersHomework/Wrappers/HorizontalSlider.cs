using System;
using OpenQA.Selenium;

namespace WrappersHomework.Wrappers
{
    public class HorizontalSlider
    {
        private BaseElementWrapper _baseElementWrapper;
        private IWebDriver _driver;
        private IJavaScriptExecutor _javaScriptExecutor;

        private const int StepSizeToRollBackToZero = 5;
        private const int FirstElementIndex = 0;
        private const int SliderMaxValue = 5;
        private const int SliderMinValue = 0;
        
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
            if ((int.Parse(SliderValue.Text) != SliderMinValue))
            {   
                SetSliderToMinValue();
            }
            
            SetSliderToValue(SliderMaxValue);
        }
        
        public void SetSliderToValue(int valueToSet)
        {
            if (valueToSet is > SliderMaxValue or < SliderMinValue)
            {
                throw new ArgumentException("Value can't be less than 0 or bigger than 5.");
            }

            if (valueToSet == SliderMinValue)
            {
                SetSliderToMinValue();
                return;
            }
            
            if (int.Parse(SliderValue.Text) != SliderMinValue)
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
