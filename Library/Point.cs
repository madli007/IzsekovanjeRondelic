using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Helper class for cylinder coordinates
    /// </summary>
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
