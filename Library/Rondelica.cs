using System;

namespace Library
{
    public class Rondelica
    {
        private Tape Tape { get; set; }
        private int Radius { get; set; }
        private int MinDistC2C { get; set; }
        private int MinDistC2Edge { get; set; }

        public Rondelica(int radius, int minDistC2C, int minDistC2Edge, Tape tape)
        {
            Radius = radius;
            MinDistC2C = minDistC2C;
            MinDistC2Edge = minDistC2Edge;
            Tape = tape;
        }

        public int CalculateNumberOfCylinders()
        {
            return 0;
        }
    }
}
