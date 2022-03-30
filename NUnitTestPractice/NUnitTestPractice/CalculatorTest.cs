using System;
using NUnit.Framework;

namespace NUnitTestPractice
{
    [TestFixture]
    [Category("SmokeTest")]
    public class Tests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Setting it up...");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tearing it down...");
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine($"\nCreated an instance of Calculator");
            _calculator = new Calculator();
        }

        [Property("Priority", 5)]
        [TestCase(5, 1, 4)]
        [TestCase(-5, -3, -2)]
        [TestCase(1, -1, 2)]
        [TestCase(0, 0, 0)]
        public void testSum(int result, int num1, int num2)
        {
            var expected = result;
            var actual = _calculator.Sum(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [Property("Priority", 5)]
        [TestCase(4, 8, 2)]
        [TestCase(2, -10, -5)]
        [TestCase(-2, 4, -2)]
        [TestCase(-2, 6, -3)]
        [TestCase(2, 7, 3)]
        public void testDiv_Int(int result, int num1, int num2)
        {
            var expected = result;
            var actual = _calculator.Div(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Data), nameof(Data.TestCases))]
        [Ignore("Ignoring to use all of the mentioned during lecture attributes :)")]
        public int testDiv_WithCaseSource(int n, int d)
        {
            return _calculator.Div(n, d);
        }

        [Property("Priority", 5)]
        [Test]
        public void When_DividedByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(delegate { _calculator.Div(0, 0); });
        }

        [Property("Priority", 5)]
        [TestCase(2, 6.6, 3.3)]
        [TestCase(-4.1, -8.2, 2)]
        [TestCase(-3.3, 3.3, -1)]
        [TestCase(55, 5.5, 0.1)]
        public void TestDiv_Double(double result, double num1, double num2)
        {
            var expected = result;
            var actual = _calculator.Div(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [Property("Priority", 0)]
        [Test]
        public void TestsForTheSakeOfAssertionsPractice()
        {
            Calculator calc;
            calc = _calculator;

            Assert.Multiple(() =>
            {
                double a = TestContext.CurrentContext.Random.NextDouble(100);
                double b = TestContext.CurrentContext.Random.NextDouble(10, 20);

                TestContext.Out.WriteLineAsync("First Double is " + a);
                TestContext.Out.WriteLineAsync($"Second Double is {b}");

                Assert.AreEqual(a / b, _calculator.Div(a, b));
                Assert.AreEqual(3.7737556561085972d, _calculator.Div(8.34, 2.21));

                Assert.True(Double.IsPositiveInfinity(_calculator.Div(8d, 0d)));
                Assert.IsTrue(Double.IsNegativeInfinity(_calculator.Div(-8d, 0d)));
                Assert.IsTrue(Double.IsNaN(_calculator.Div(0d, 0d)));
            });

            Assert.AreSame(_calculator, calc);

            var iLoveDogs = true;

            Assert.IsTrue(iLoveDogs);

            var myLoveToCats = 50;
            var myLoveToDogs = 100;

            Assert.Greater(myLoveToDogs, myLoveToCats);
            //Assert.Pass();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Planned tests were run");
        }
    }
}
