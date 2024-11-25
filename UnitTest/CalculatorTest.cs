using NUnit.Framework;
using NUnit.Framework.Legacy;
using SportApp_Infrastructure;

namespace UnitTest
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _cal;

        [SetUp]
        public void Setup()
        {
            _cal = new Calculator();
        }

        [Test]
        public void OnePlusOneEqualTwo()
        {
            ClassicAssert.AreEqual(2, _cal.Add(1, 1));
        }

        [Test]
        public void TwoPlusTwoEqualFour()
        {
            ClassicAssert.AreEqual(4, _cal.Add(2, 2));
        }

        [Test]
        public void FourPlusOneEqualFive()
        {
            ClassicAssert.AreEqual(5, _cal.Add(4, 1));
        }
    }
}
