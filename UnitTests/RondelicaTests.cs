using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RondelicaTests
    {
        [TestMethod]
        public void RecPatternNoSpacing()
        {
            int radius = 10;
            int minDistC2C = 0;
            int minDistC2Edge = 0;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecPatternSpaceToEdge()
        {
            int radius = 10;
            int minDistC2C = 0;
            int minDistC2Edge = 5;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecPatternSpaceBetweenCylinders()
        {
            int radius = 10;
            int minDistC2C = 5;
            int minDistC2Edge = 0;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecPatternBothSpacing()
        {
            int radius = 10;
            int minDistC2C = 5;
            int minDistC2Edge = 10;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TrianglePatternNoSpacing()
        {
            int radius = 10;
            int minDistC2C = 0;
            int minDistC2Edge = 0;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrianglePatternSpaceToEdge()
        {
            int radius = 10;
            int minDistC2C = 0;
            int minDistC2Edge = 5;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrianglePatternSpaceBetweenCylinders()
        {
            int radius = 10;
            int minDistC2C = 5;
            int minDistC2Edge = 0;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrianglePatternBothSpacing()
        {
            int radius = 10;
            int minDistC2C = 5;
            int minDistC2Edge = 10;
            int length = 200;
            int width = 100;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }
    }
}
