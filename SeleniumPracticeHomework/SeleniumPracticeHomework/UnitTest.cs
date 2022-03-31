using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPracticeHomework
{
    [Category("SmokeTests")]
    public class Tests
    {
        private IWebDriver _driver;
        private Actions _actions;
        private const int ThreeSecondWait = 3000;
        
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void SmokeTest2()
        {
            _driver.Navigate().GoToUrl(Endpoints.LaminateCalculatorFullUrl);
            
            var layingMethod = _driver.FindElement(By.Id("laying_method_laminate"));
            var layingMethodDropDown = new SelectElement(layingMethod);
            
            var roomLength = _driver.FindElement(By.Id("ln_room_id"));
            var roomWidth = _driver.FindElement(By.Id("wd_room_id"));
            var laminateLength = _driver.FindElement(By.Id("ln_lam_id"));
            var laminateWidth = _driver.FindElement(By.Id("wd_lam_id"));
            var laminateDirection = _driver.FindElement(By.Id("direction-laminate-id1"));
            var calculateButton = _driver.FindElement(By.ClassName("calc-btn-div")).FindElement(By.TagName("a"));

            layingMethodDropDown.SelectByIndex(0);
            ClearAndFill(roomLength, "500");
            ClearAndFill(roomWidth, "400");
            ClearAndFill(laminateLength, "2000");
            ClearAndFill(laminateWidth, "200");
            
            laminateDirection.Click();
            calculateButton.Click();
            Thread.Sleep(ThreeSecondWait);

            var laminatePieces = _driver.FindElement(By.XPath("//*[contains(text(), 'досок')]/span"));
            var laminatePacks = _driver.FindElement(By.XPath("//*[contains(text(), 'упаковок')]/span"));
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual("51", laminatePieces.Text);
                Assert.AreEqual("7", laminatePacks.Text);
            });
        }
        
        [Test]
        public void TestElectricFloorHeatingCalculator()
        {
            _driver.Navigate().GoToUrl(Endpoints.ElectricFloorHeatingCalculatorFullUrl);

            var width = _driver.FindElement(By.Id("el_f_width"));
            var length = _driver.FindElement(By.Id("el_f_lenght"));
            var electricityLoss = _driver.FindElement(By.Id("el_f_losses"));
            var calculate = _driver.FindElement(By.ClassName("buttHFcalc"));
            var floorCablePower = _driver.FindElement(By.Id("floor_cable_power"));
            var specFloorCablePower = _driver.FindElement(By.Id("spec_floor_cable_power"));

            var roomType = _driver.FindElement(By.Id("room_type"));
            var roomTypeDropDown = new SelectElement(roomType);
            var heatingType = _driver.FindElement(By.Id("heating_type"));
            var heatingTypeDropDown = new SelectElement(heatingType);

            ClearAndFill(width, "34");
            ClearAndFill(length, "20");

            roomTypeDropDown.SelectByIndex(1);
            heatingTypeDropDown.SelectByIndex(2);

            ClearAndFill(electricityLoss, "1255");

            calculate.Click();
            Thread.Sleep(ThreeSecondWait);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("698", floorCablePower.GetAttribute("value"));
                Assert.AreEqual("1", specFloorCablePower.GetAttribute("value"));
            });
        }

        [Test]
        public void TestLaminateFlooringCalculator()
        {
            _driver.Navigate().GoToUrl(Endpoints.LaminateFlooringCalculatorFullUrl);

            var roomWidth = _driver.FindElement(By.Name("calc_roomwidth"));
            var roomLength = _driver.FindElement(By.Name("calc_roomheight"));
            var laminateWidth = _driver.FindElement(By.Name("calc_lamwidth"));
            var laminateHeight = _driver.FindElement(By.Name("calc_lamheight"));
            var laminateInPack = _driver.FindElement(By.Name("calc_inpack"));
            var laminatePrice = _driver.FindElement(By.Name("calc_price"));
            var bias = _driver.FindElement(By.Name("calc_bias"));
            var wallDistance = _driver.FindElement(By.Name("calc_walldist"));
            var resultButton = _driver.FindElement(By.ClassName("btn-secondary"));
            var areaLaminated = _driver.FindElement(By.Id("s_lam")).FindElement(By.TagName("b"));
            var laminateCount = _driver.FindElement(By.Id("l_count")).FindElement(By.TagName("b"));
            var laminatePacks = _driver.FindElement(By.Id("l_packs")).FindElement(By.TagName("b"));
            var laminateTotalPrice = _driver.FindElement(By.Id("l_price")).FindElement(By.TagName("b"));
            var laminateLeftOver = _driver.FindElement(By.Id("l_over")).FindElement(By.TagName("b"));
            var laminateTrash = _driver.FindElement(By.Id("l_trash")).FindElement(By.TagName("b"));

            var laminateDirection = _driver.FindElement(By.Name("calc_direct"));
            var laminateDirectionDropDown = new SelectElement(laminateDirection);

            ClearAndFill(roomWidth, "10");
            ClearAndFill(roomLength, "10");
            ClearAndFill(laminateWidth, "1300");
            ClearAndFill(laminateHeight, "208");
            ClearAndFill(laminateInPack, "12");
            ClearAndFill(laminatePrice, "1200");

            laminateDirectionDropDown.SelectByIndex(1);

            ClearAndFill(bias, "350");
            ClearAndFill(wallDistance, "5");

            resultButton.Click();
            Thread.Sleep(ThreeSecondWait);

            Assert.Multiple(() =>
            {
                Assert.AreEqual("99.80", areaLaminated.Text);
                Assert.AreEqual("380", laminateCount.Text);
                Assert.AreEqual("32", laminatePacks.Text);
                Assert.AreEqual("124600", laminateTotalPrice.Text);
                Assert.AreEqual("4", laminateLeftOver.Text);
                Assert.AreEqual("13", laminateTrash.Text);
            });
        }
        
        private void ClearAndFill(IWebElement element, string valueToInsert)
        {
            _actions = new Actions(_driver);
            _actions.MoveToElement(element).DoubleClick(element).Click().Perform();
            element.SendKeys(valueToInsert);
        }
        
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
