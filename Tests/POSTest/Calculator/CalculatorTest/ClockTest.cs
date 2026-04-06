using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
namespace CalculatorTest
{
    [TestClass]
    public class ClockTest
    {
        [TestMethod]
        public void TestMinuteToAngle()
        {
          
            Clock c = new Clock();

            Assert.AreEqual(c.GetMinuteToHrAngle(12,15), 90);

            
            Assert.AreEqual(c.GetMinuteToHrAngle(6,45), 90);

            
            Assert.AreEqual(c.GetMinuteToHrAngle(3,45), 180);

            
            Assert.AreEqual(c.GetMinuteToHrAngle(1,27), 132);

            Assert.IsTrue(true, "All tests Passed");




        }
    }
}
