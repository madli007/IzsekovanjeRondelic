using System;
using System.Drawing;

namespace Library
{
    public class Rondelica
    {
        public Point Position { get; private set; }
        public int Radius { get; private set; }
        public int MinDistC2C { get; private set; }
        public int MinDistC2Edge { get; private set; }

        public Rondelica(int radius, int minDistC2C, int minDistC2Edge, Point position)
        {
            Radius = radius;
            MinDistC2C = minDistC2C;
            MinDistC2Edge = minDistC2Edge;
            Position = position;
        }
    }
}
