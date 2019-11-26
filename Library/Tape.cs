using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Library
{
    public class Tape
    {
        private int Length { get; set; }
        private int Width { get;  set; }
        public List<Point> PointsOfOrigin { get; set; }
        public int[,] Matrix { get; private set; }

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
        }

        private void AddCylinderToMatrix(Rondelica r)
        {
            Matrix[r.Position.X, r.Position.Y] = 1;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", Matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        public int MaxNumberOfCylindersRecPattern(Rondelica r)
        {
            int diameter = r.Radius * 2;
            int space = r.MinDistC2C;
            List<Rondelica> listOfCylinders = new List<Rondelica>();
            Point point = new Point();
            if (Length > 0 && Width > 0 && diameter > 0)
            {
                if ((diameter + space) < Length && (diameter + space) < Width)
                {
                    point.X = (diameter / 2) + space;
                    point.Y = (diameter / 2) + space;
                    do
                    {
                        do
                        {
                            Rondelica rondelica = new Rondelica(diameter / 2, r.MinDistC2C, r.MinDistC2Edge, point);
                            listOfCylinders.Add(rondelica);
                            point.X += diameter + space;
                        } while (point.X + (diameter / 2) + space <= Length);
                        point.X = (diameter / 2) + space;
                        point.Y += diameter + space;
                    } while (point.Y + (diameter / 2) + space <= Width);
                }
            }
            else
            {
                Console.WriteLine("Wrong values");
            }
            return listOfCylinders.Count;
        }
    }
}
