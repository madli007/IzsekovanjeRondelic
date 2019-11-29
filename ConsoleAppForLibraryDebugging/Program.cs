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
            int radius = 444;
            int minDistC2C = 138;
            int minDistC2Edge = 0;
            int length = 3032;
            int width = 888;

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
