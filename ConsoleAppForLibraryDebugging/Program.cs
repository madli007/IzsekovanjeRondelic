using Library;
using System;

namespace ConsoleAppForLibraryDebugging
{
    /// <summary>
    /// Intended for debugging purposes
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
           /* int radius = 1;
            int minDistC2C = 0;
            int minDistC2Edge = 0;
            int length = 13;
            int width = 13;*/

            int radius = 100;
            int minDistC2C = 0;
            int minDistC2Edge = 0;
            int length = 2000;
            int width = 1000;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int a = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            Console.WriteLine(a);

            int b = tape.MaxNumberOfCylindersRecPattern(rondelica);
            Console.WriteLine(b);

            Console.WriteLine("----------------");

            int c = tape.GetPositionsOfCylindersTriangularPattern(rondelica).Count;
            int d = tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Console.WriteLine(c + " " + d);

            Console.Read();
        }
    }
}
