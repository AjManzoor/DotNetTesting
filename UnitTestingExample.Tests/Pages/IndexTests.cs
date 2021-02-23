using NUnit.Framework;
using System;
using UnitTestingExample.Pages;

namespace UnitTestingExample.Tests.Pages
{
    [TestFixture]
    public class IndexTests
    {
        [Test]
        public void ParsePort_COM1_Returns1()
        {
            //call method
            int result= IndexModel.ParsePort("COM1");

            Assert.That(result, Is.EqualTo(1));
        }

        //check exceptions
        [Test]
        public void ParsePort_InvalidFormat_ThrowsInvalidFormatException()
        {
            TestDelegate action = () => IndexModel.ParsePort("1");
            Assert.Throws<FormatException>(action);
        }

        [Test]
        public void ToFarhenheit_UserEntersInput_Returns_Value()
        {
            var indexModel = new IndexModel(null);
            double result = indexModel.ToFahrenheit(0.0d);
            Assert.That(result, Is.EqualTo(32.0d));
        }

        [Test]
        public void ToCelcius_Enters0_Returns_32()
        {
            var indexModel = new IndexModel(null);
            double result = indexModel.ToCelcius(1.0d);
            Assert.That(result, Is.EqualTo(0.0d));
        }

        
    }
}
