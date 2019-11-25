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
            int radius = 27;
            int minDistC2C = 12;
            int minDistC2Edge = 18;

            Tape t = new Tape(30000, 100);

            Rondelica r = new Rondelica(radius, minDistC2C, minDistC2Edge, t);
            int a = r.CalculateMaxNumberOfCylinders();

            Assert.AreEqual(0, a);
        }
    }
}
