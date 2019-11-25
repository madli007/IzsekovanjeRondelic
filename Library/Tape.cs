using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Library
{
    public class Tape
    {
        public int Length { get; private set; }
        public int Width { get;  private set; }
        public List<Point> PointsOfOrigin { get; set; }
        public int[,] Matrix { get; set; }

        public Tape(int length, int width)
        {
            Length = length;
            Width = width;
            PointsOfOrigin = new List<Point>();
            Matrix = new int[length, width];
            PopulateMatrix();
        }

        private void PopulateMatrix()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = 0;
                }
            }

            PrintMatrix();
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", Matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
