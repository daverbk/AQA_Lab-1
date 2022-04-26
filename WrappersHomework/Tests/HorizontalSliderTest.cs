using System;
using NUnit.Framework;
using WrappersHomework.Pages;
using WrappersHomework.Wrappers;

namespace WrappersHomework.Tests
{
    public class HorizontalSliderTest : BaseTest
    {
        private HorizontalSliderPage _horizontalSliderPage;
    
        [SetUp]
        public new void SetUp()
        {
            _horizontalSliderPage = new HorizontalSliderPage(Driver);
            _horizontalSliderPage.NavigateToPageAndWaitUntilOpened();
        }
    
        [Test]
        public void HorizontalSliderMaxMinTests()
        {
            _horizontalSliderPage.Slider.SetSliderToMaxValue();
            Assert.AreEqual(HorizontalSlider.SliderMaxValue , decimal.Parse(_horizontalSliderPage.SliderValue.Text));
            
            _horizontalSliderPage.Slider.SetSliderToMinValue();
            Assert.AreEqual(HorizontalSlider.SliderMinValue, decimal.Parse(_horizontalSliderPage.SliderValue.Text));
        }
        
        [TestCase(5)]
        [TestCase(4.5)]
        [TestCase(4)]
        [TestCase(1)]
        [TestCase(0.5)]
        [TestCase(0)]
        [Test]
        public void HorizontalSliderPositiveTests(decimal valueToSet)
        {
            _horizontalSliderPage.Slider.SetSliderToValue(valueToSet);
            Assert.AreEqual(valueToSet, decimal.Parse(_horizontalSliderPage.SliderValue.Text));
        }

        [Test]
        public void HorizontalSliderNegativeTests()
        {
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(-1));
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(6));
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(0.1m));
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(-0.1m));
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(4.9m));
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(5.1m));
        }
    }
}
