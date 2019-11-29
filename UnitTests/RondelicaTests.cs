using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class RondelicaTests
    {
        [TestMethod]
        public void RecPatternNoSpacing()
        {
            int radius = 100;
            int minDistC2C = 0;
            int minDistC2Edge = 0;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecPatternSpaceToEdge()
        {
            int radius = 100;
            int minDistC2C = 0;
            int minDistC2Edge = 50;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecPatternSpaceBetweenCylinders()
        {
            int radius = 100;
            int minDistC2C = 50;
            int minDistC2Edge = 0;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecPatternBothSpacing()
        {
            int radius = 100;
            int minDistC2C = 50;
            int minDistC2Edge = 100;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TrianglePatternNoSpacing()
        {
            int radius = 100;
            int minDistC2C = 0;
            int minDistC2Edge = 0;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrianglePatternSpaceToEdge()
        {
            int radius = 100;
            int minDistC2C = 0;
            int minDistC2Edge = 50;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrianglePatternSpaceBetweenCylinders()
        {
            int radius = 100;
            int minDistC2C = 50;
            int minDistC2Edge = 0;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TrianglePatternBothSpacing()
        {
            int radius = 100;
            int minDistC2C = 50;
            int minDistC2Edge = 100;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int actual = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int expected = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RecPatternRandomInputMultipleTests()
        {
            int numberOfTests = 10000;

            for (int i = 0; i < numberOfTests; i++)
            {
                Random rnd = new Random();

                int radius = rnd.Next(1000);
                int minDistC2C = rnd.Next(200);
                int minDistC2Edge = rnd.Next(200);
                int length = rnd.Next(10000);
                int width = rnd.Next(10000);

                Tape tape = new Tape(length, width);

                Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
                int actual = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
                int expected = tape.MaxNumberOfCylindersRecPattern(rondelica);

                string output = "radius: " + radius + ", minDistC2C: " + minDistC2C
                    + ", minDistC2Edge: " + minDistC2Edge + ", length: " + length + ", width: " + width;

                Assert.AreEqual(expected, actual, output);
            }
        }
    }
}
