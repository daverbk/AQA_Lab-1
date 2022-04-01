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
            Console.WriteLine("Created an instance of Calculator");
            _calculator = new Calculator();
        }

        [Property("Priority", 5)]
        [TestCase(1, 4, 5)]
        [TestCase(-3, -2, -5)]
        [TestCase(-1, 2, 1)]
        [TestCase(1, -2, -1)]
        [TestCase(-2, 1, -1)]
        [TestCase(0, 0, 0)]
        public void TestSum(int num1, int num2, int result)
        {
            var expected = result;
            var actual = _calculator.Sum(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [Property("Priority", 5)]
        [TestCase(8, 2, 4)]
        [TestCase(-10, -5, 2)]
        [TestCase(6, -3, -2)]
        [TestCase(7, 3, 2)]
        public void TestDivInt(int num1, int num2, int result)
        {
            var expected = result;
            var actual = _calculator.Div(num1, num2);

            Assert.AreEqual(expected, actual);
        }

        [Property("Priority", 4)]
        [Test]
        public void When_IntDividedByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(delegate { _calculator.Div(0, 0); });
        }

        [Property("Priority", 5)]
        [TestCase(6.6, 3.3, 2)]
        [TestCase(-8.2, 2, -4.1)]
        [TestCase(3.3, -1, -3.3)]
        [TestCase(5.5, 0.1, 55)]
        public void TestDivDouble(double num1, double num2, double result)
        {
            var expected = result;
            var actual = _calculator.Div(num1, num2);

            Assert.AreEqual(expected, actual);
        }
        
        [Property("Priority", 4)]
        [Test]
        public void When_DoubleDividedByZero_ReturnsInfinity()
        {
            Assert.Multiple(() => 
            {
                Assert.True(Double.IsPositiveInfinity(_calculator.Div(8d, 0d)));
                Assert.IsTrue(Double.IsNegativeInfinity(_calculator.Div(-8d, 0d)));
                Assert.IsTrue(Double.IsNaN(_calculator.Div(0d, 0d)));
            });
        }
        
        // DEVNOTE: Next two methods are here just for practice purposes (as was mentioned in the task: to use all
        // of the assertions and attributes we covered during the lecture).
        [Property("Priority", 1)]
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
            });

            Assert.AreSame(_calculator, calc);

            var iLoveDogs = true;
            Assert.IsTrue(iLoveDogs);
            var myLoveToCats = 50;
            var myLoveToDogs = 100;

            Assert.Greater(myLoveToDogs, myLoveToCats);
            Assert.Pass();
        }

        [TestCaseSource(typeof(Data), nameof(Data.TestCases))]
        [Ignore("Ignoring to use all of the mentioned during lecture attributes :)")]
        public int TestDivWithCaseSource(int num1, int num2)
        {
            return _calculator.Div(num1, num2);
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Planned tests were run");
        }
    }
}
