using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RondelicaTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int radius = 100;
            int minDistC2C = 100;
            int minDistC2Edge = 100;

            Tape t = new Tape(100, 100);

            Rondelica r = new Rondelica(radius, minDistC2C, minDistC2Edge, t);
            int a = r.CalculateNumberOfCylinders();

            Assert.AreEqual(0, a);
        }
    }
}
