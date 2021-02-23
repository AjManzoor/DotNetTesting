using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitTestingExample;

namespace TestingExample.IntergrationTests
{
    public class CalculatorIntergrationTests
    {
        private string _filePath = @"c:\temp\test.txt";
        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);
        }

        private FileStore CreateFileStore()
        {
            return new FileStore(_filePath);
        }

        [Test]
        public void Add_ResultsIsPrime_CreateFiles()
        {
            FileStore store = CreateFileStore();
            Calculator calc = new Calculator(store);
            var result = calc.Add("3,4");
            Assert.IsTrue(File.Exists(_filePath));
        }

        [Test]
        public void Add_NumberIsPrime_WritesCorrectResultsToFile()
        {
            FileStore store = CreateFileStore();
            Calculator calc = new Calculator(store);
            calc.Add("3,4");

            var expectedResult = "7";
            var storedResult = File.ReadLines(_filePath).FirstOrDefault();
            Assert.AreEqual(expectedResult, storedResult);
        }

        [TearDown]
        public void CleanUp()
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);
        }
    }
}
