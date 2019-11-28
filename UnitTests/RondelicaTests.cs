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
            // 21 bi moglo bit
            int radius = 10;
            int minDistC2C = 5;
            int minDistC2Edge = 10;

            Tape t = new Tape(200, 100);

            Rondelica r = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int a = t.MaxNumberOfCylindersRecPattern(r);

            Assert.AreEqual(21, a);
        }
    }
}
