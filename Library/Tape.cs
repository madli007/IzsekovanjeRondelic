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
        public string[,] Matrix { get; private set; }

        public Tape(int length, int width)
        {
            Length = length;
            Width = width;
            PointsOfOrigin = new List<Point>();
            Matrix = new string[length, width];
            PopulateMatrix();
        }

        private void PopulateMatrix()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = "-";
                }
            }
        }

        private void AddCylinderToMatrix(Rondelica r)
        {
            Matrix[r.Position.X, r.Position.Y] = "*";

            for (int x = r.Position.X; x < r.Position.X + r.Radius; x++)
            {
                for (int y = r.Position.Y; y < r.Position.Y + r.Radius; y++)
                {
                    Matrix[x, y] = "2";
                }
            }

            for (int x = r.Position.X + r.Radius; x > r.Position.X; x--)
            {
                for (int y = r.Position.Y + r.Radius; y > r.Position.Y; y--)
                {
                    Matrix[x, y] = "1";
                }
            }
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
            int spaceToWalls = r.MinDistC2Edge;
            int spaceToCylinder = r.MinDistC2C;
            List<Rondelica> listOfCylinders = new List<Rondelica>();
            Point point = new Point();
            if (Length > 0 && Width > 0 && diameter > 0)
            {
                if ((diameter + spaceToWalls) < Length && (diameter + spaceToWalls) < Width)
                {
                    point.X = (diameter / 2) + spaceToCylinder;
                    point.Y = (diameter / 2) + spaceToCylinder;
                    do
                    {
                        do
                        {
                            Rondelica rondelica = new Rondelica(diameter / 2, r.MinDistC2C, r.MinDistC2Edge, point);
                            PointsOfOrigin.Add(point);
                            listOfCylinders.Add(rondelica);
                            AddCylinderToMatrix(rondelica);
                            point.X += diameter + spaceToCylinder;
                        } while (point.X + (diameter / 2) + spaceToWalls <= Length);
                        point.X = (diameter / 2) + spaceToCylinder;
                        point.Y += diameter + spaceToCylinder;
                    } while (point.Y + (diameter / 2) + spaceToWalls <= Width);
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
