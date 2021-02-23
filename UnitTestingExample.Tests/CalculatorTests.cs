using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExample.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Mock<IStore> _mockStore;
        private Calculator GetCalculator()
        {
            _mockStore = new Mock<IStore>();
            return new Calculator(_mockStore.Object);
        }

        [Test]
        public void Add_EmptyString_Returns_0()
        {
            var calc = GetCalculator();
            int expectedResult = 0;
            int result = calc.Add("");
            Assert.AreEqual(expectedResult, result);

        }
        //[Test]
        //public void Add_SingleNumbers_ReturnsTheNumber()
        //{
        //    var calc = new Calculator();
        //    int expectedResult = 3;
        //    int result = calc.Add("3");
        //    Assert.AreEqual(expectedResult, result);
        //}

        //Can pass parameters to multiple test cases
        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        [TestCase("5", 5)]
        [TestCase("6", 6)]
        public void Add_SingleNumbers_ReturnsTheNumber(string input, int expectedResult)
        {
            var calc = GetCalculator();
            int result = calc.Add(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,2,4", 7)]
        [TestCase("2,2,4", 8)]
        public void Add_MultipleNumbers_SumOfAllNumbers(string input, int expectedResult)
        {
            var calc = GetCalculator(); ;
            int result = calc.Add(input);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("a,100")]
        [TestCase("*&,100")]
        [TestCase("a,dcf,!!!!")]
        public void Add_InvalidString_ThrowsException(string input)
        {
            Calculator calc = GetCalculator();
            TestDelegate action = ()=> calc.Add(input);
            Assert.Throws<ArgumentException>(action);
        }

        [TestCase("2")]
        [TestCase("5,6")]
        [TestCase("10,2,1")]
        public void Add_ResultIsAPrimeNumber_ResultsAre_Saved(string input)
        {            
            Calculator calc = GetCalculator();

            var result = calc.Add(input);

            _mockStore.Verify(m => m.Save(It.IsAny<int>()), Times.Once);
        }

        [TestCase("2,2")]
        [TestCase("5,6,1")]
        [TestCase("10,2,1,1")]
        public void Add_ResultIsNotAPrimeNumber_ResultsAreNot_Saved(string input)
        {
            Calculator calc = GetCalculator();

            var result = calc.Add(input);

            _mockStore.Verify(m => m.Save(It.IsAny<int>()), Times.Never);
        }
    }
}
