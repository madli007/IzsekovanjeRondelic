using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Tape
    {
        private int Width { get; set; }
        private int Length { get; set; }

        public Tape(int width, int length)
        {
            Width = width;
            Length = length;
        }
    }
}
