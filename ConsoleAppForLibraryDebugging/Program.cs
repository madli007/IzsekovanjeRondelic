using Library;
using System;
using System.Drawing;

namespace ConsoleAppForLibraryDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            int radius = 10;
            int minDistC2C = 5;
            int minDistC2Edge = 10;

            Tape t = new Tape(200, 100);

            Rondelica r = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int a = t.MaxNumberOfCylindersRecPattern(r);
            t.PrintMatrix();
            Console.WriteLine(a);

            Console.Read();
        }
    }
}
