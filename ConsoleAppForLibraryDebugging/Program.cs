using Library;
using System;

namespace ConsoleAppForLibraryDebugging
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int radius = 50;
            int minDistC2C = 10;
            int minDistC2Edge = 144;
            int length = 90;
            int width = 3615;

            Tape tape = new Tape(length, width);

            Rondelica rondelica = new Rondelica(radius, minDistC2C, minDistC2Edge, new Point());
            int a = tape.GetPositionsOfCylindersRecPattern(rondelica).Count;
            Console.WriteLine(a);

            int b = tape.MaxNumberOfCylindersRecPattern(rondelica);
            Console.WriteLine(b);
            tape.MaxNumberOfCylindersTriangularPattern(rondelica);

            Console.Read();
        }
    }
}
