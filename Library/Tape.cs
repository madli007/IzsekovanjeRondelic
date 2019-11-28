using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// 
    /// </summary>
    public class Tape
    {
        public int Length { get; private set; }
        public int Width { get; private  set; }
        public List<Rondelica> ListOfCylinders { get; private set; }

        public Tape(int length, int width)
        {
            Length = length;
            Width = width;
            ListOfCylinders = new List<Rondelica>();
        }

        /// <summary>
        /// Calculate max number of cylinders that can be cut from rectangle with rectangle pattern method
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<Rondelica> GetPositionsOfCylindersRecPattern(Rondelica r)
        {
            int diameter = r.Radius * 2;
            int spaceToWalls = r.MinDistC2Edge;
            int spaceToCylinder = r.MinDistC2C;
            List<Rondelica> listOfCylinders = new List<Rondelica>();
            int x = 0;
            int y = 0;

            if (Length > 0 && Width > 0 && diameter > 0)
            {
                if ((diameter + spaceToWalls) < Length && (diameter + spaceToWalls) < Width)
                {
                    x = (diameter / 2) + spaceToWalls;
                    y = (diameter / 2) + spaceToWalls;
                    do
                    {
                        do
                        {
                            Rondelica rondelica = new Rondelica(diameter / 2, r.MinDistC2C, r.MinDistC2Edge, new Point(x, y));
                            listOfCylinders.Add(rondelica);
                            x += diameter + spaceToCylinder;
                        } while (x + (diameter / 2) + spaceToWalls <= Length);
                        x = (diameter / 2) + spaceToWalls;
                        y += diameter + spaceToCylinder;
                    } while (y + (diameter / 2) + spaceToWalls <= Width);
                }
            }
            else
            {
                Console.WriteLine("Wrong values");
            }
            ListOfCylinders = listOfCylinders;
            return listOfCylinders;
        }

        /// <summary>
        /// Calculate max number of cylinders that can be cut from rectangle with triangle pattern method
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<Rondelica> GetPositionsOfCylindersTriangularPattern(Rondelica r)
        {
            // TODO: fix

            int diameter = r.Radius * 2;
            int spaceToWalls = r.MinDistC2Edge;
            int spaceToCylinder = r.MinDistC2C;
            List<Rondelica> listOfCylinders = new List<Rondelica>();
            int x = 0;
            int y = 0;

            if (Length > 0 && Width > 0 && diameter > 0)
            {
                if ((diameter + spaceToWalls) < Length && (diameter + spaceToWalls) < Width)
                {
                    x = diameter / 2 + spaceToWalls;
                    y = diameter / 2 + spaceToWalls;
                    int triangle = 0;
                    do
                    {
                        do
                        {
                            Rondelica circle = new Rondelica(diameter / 2, r.MinDistC2C, r.MinDistC2Edge, new Point(x, y));
                            listOfCylinders.Add(circle);
                            x += diameter + spaceToCylinder;
                        } while (x + diameter / 2 + spaceToWalls <= Length);
                        if (triangle == 0)
                        {
                            x = (int)(diameter + 1.5 * spaceToWalls);
                            triangle = 1;
                        }
                        else
                        {
                            x = diameter / 2 + spaceToWalls;
                            triangle = 0;
                        }
                        y = (int)(y + Math.Pow(Math.Pow((diameter + spaceToWalls), 2) * 0.75, 0.5));
                    } while (y + diameter / 2 + spaceToWalls <= Width);
                }
            }

            ListOfCylinders = listOfCylinders;
            return listOfCylinders;
        }

        public int MaxNumberOfCylindersRecPattern(Rondelica rondelica)
        {
            int cylindersPerLine = (Length - rondelica.MinDistC2Edge * 2) / (rondelica.Radius * 2 + rondelica.MinDistC2C);
            int cylindersPerColumn = (Width - rondelica.MinDistC2Edge * 2) / (rondelica.Radius * 2 + rondelica.MinDistC2C);
            int result = cylindersPerLine * cylindersPerColumn;
            return result;
        }

        public int MaxNumberOfCylindersTriangularPattern(Rondelica rondelica)
        {
            // TODO: fix
            int nrOfLines = Width / rondelica.Radius;
            int nrOfColumns = (int)(Length / (rondelica.Radius * Math.Sqrt(3)));

            int cylindersPerLine = nrOfLines / 2 - 1;
            int cylindersPerColumn = nrOfColumns;

            int result = cylindersPerLine * cylindersPerColumn;

            return result;
        }
    }
}
