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

        public int CalculateMaxNumberOfCylinders()
        {
            // in one line - test
            //int a = Tape.Length / ((Radius * 2) + MinDistC2C + MinDistC2Edge);
            //int b = (int)a;

            int counter = 0;
            bool space = true;

            while (space == true)
            {
                for (int x = 0; x < Tape.Length; x++)
                {
                    for (int y = 0; y < Tape.Width; y++)
                    {
                        // TODO
                        if (Tape.Matrix[x, y] == 0 
                            && x > MinDistC2Edge 
                            && y > MinDistC2Edge
                            && x < Tape.Length - (Radius + MinDistC2Edge)
                            && y < Tape.Width - (Radius + MinDistC2Edge)
                            && x > Radius * 2 + MinDistC2C
                            )
                        {

                        }
                    }
                }
                counter++;
                space = false;
            }

            return counter;
        }
    }
}
