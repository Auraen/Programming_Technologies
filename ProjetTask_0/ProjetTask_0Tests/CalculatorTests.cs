using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetTask_0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTask_0.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void should_return_same_value()
        {
            int expected = 5;
            int actual = Calculator.Addition(2, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void should_return_different_value()
        {
            int expected = 9;
            int actual = Calculator.Addition(2, 3);

            Assert.AreNotEqual(expected, actual);
        }
    }
}