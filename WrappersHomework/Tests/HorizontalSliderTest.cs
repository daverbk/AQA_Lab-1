using System;
using NUnit.Framework;
using WrappersHomework.Pages;

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
            Assert.AreEqual(5, int.Parse(_horizontalSliderPage.SliderValue.Text));
            
            _horizontalSliderPage.Slider.SetSliderToMinValue();
            Assert.AreEqual(0, int.Parse(_horizontalSliderPage.SliderValue.Text));
        }
        
        [TestCase(5)]
        [TestCase(4)]
        [TestCase(1)]
        [TestCase(0)]
        [Test]
        public void HorizontalSliderPositiveTests(int valueToSet)
        {
            _horizontalSliderPage.Slider.SetSliderToValue(valueToSet);
            Assert.AreEqual(valueToSet, int.Parse(_horizontalSliderPage.SliderValue.Text));
        }

        [Test]
        public void HorizontalSliderNegativeTests()
        {
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(-1));
            Assert.Throws<ArgumentException>(() => _horizontalSliderPage.Slider.SetSliderToValue(6));
        }
    }
}
