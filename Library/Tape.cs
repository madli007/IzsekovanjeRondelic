using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    /// <summary>
    /// Tape class
    /// </summary>
    public class Tape
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        public List<Rondelica> ListOfCylinders { get; private set; }

        public Tape(int length, int width)
        {
            Length = length;
            Width = width;
            ListOfCylinders = new List<Rondelica>();
        }

        /// <summary>
        /// Calculate positions of cylinders with rectangle pattern method
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<Rondelica> GetPositionsOfCylindersRecPattern(Rondelica r)
        {
            int diameter = r.Radius * 2;
            int spaceToEdge = r.MinDistC2Edge;
            int spaceToCylinder = r.MinDistC2C;
            List<Rondelica> listOfCylinders = new List<Rondelica>();
            int x = 0;
            int y = 0;

            if (Length > 0 && Width > 0 && diameter > 0)
            {
                if ((diameter + spaceToEdge) <= Length && (diameter + spaceToEdge) <= Width)
                {
                    x = (diameter / 2) + spaceToEdge;
                    y = (diameter / 2) + spaceToEdge;
                    do
                    {
                        do
                        {
                            Rondelica rondelica = new Rondelica(diameter / 2, r.MinDistC2C, r.MinDistC2Edge, new Point(x, y));
                            // check space on the right of the cylinder
                            if ((rondelica.Position.X + rondelica.Radius + spaceToEdge <= Length) &&
                                rondelica.Position.Y + rondelica.Radius + spaceToEdge <= Width)
                            {
                                listOfCylinders.Add(rondelica);
                            }
                            // increase x for diameter and space between cylinders
                            x += diameter + spaceToCylinder;
                        } while (x + (diameter / 2) + spaceToEdge <= Length);
                        x = (diameter / 2) + spaceToEdge;

                        // increase y for diameter and space between cylinders
                        y += diameter + spaceToCylinder;
                    } while (y + (diameter / 2) + spaceToEdge <= Width);
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
        /// Calculate positions of cylinders with triangle pattern method
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<Rondelica> GetPositionsOfCylindersTriangularPattern(Rondelica r)
        {
            // TODO: fix

            int diameter = r.Radius * 2;
            int spaceToEdge = r.MinDistC2Edge;
            int spaceToCylinder = r.MinDistC2C;
            List<Rondelica> listOfCylinders = new List<Rondelica>();
            int x = 0;
            int y = 0;

            if (Length > 0 && Width > 0 && diameter > 0)
            {
                if ((diameter + spaceToEdge) <= Length && (diameter + spaceToEdge) <= Width)
                {
                    x = diameter / 2 + spaceToEdge;
                    y = diameter / 2 + spaceToEdge;
                    int triangle = 0;
                    do
                    {
                        do
                        {
                            Rondelica circle = new Rondelica(diameter / 2, r.MinDistC2C, r.MinDistC2Edge, new Point(x, y));
                            listOfCylinders.Add(circle);
                            // increase x for diameter and space between cylinders
                            x += diameter + spaceToCylinder;
                        } while (x + diameter / 2 + spaceToEdge <= Length);
                        if (triangle == 0)
                        {
                            x = (int)(diameter + 1.5 * spaceToEdge);
                            triangle = 1;
                        }
                        else
                        {
                            x = diameter / 2 + spaceToEdge;
                            triangle = 0;
                        }
                        y = (int)(y + Math.Pow(Math.Pow((diameter + spaceToEdge), 2) * 0.75, 0.5));
                    } while (y + diameter / 2 + spaceToEdge <= Width);
                }
            }

            ListOfCylinders = listOfCylinders;
            return listOfCylinders;
        }

        /// <summary>
        /// Calculate max number of cylinders that can be cut from rectangle with rectangle pattern method
        /// </summary>
        /// <param name="rondelica"></param>
        /// <returns></returns>
        public int MaxNumberOfCylindersRecPattern(Rondelica rondelica)
        {
            // need to add 1 more spacing to length and width since the last spacing is already counted with space to edge
            int cylindersPerLine = (Length - rondelica.MinDistC2Edge * 2 + rondelica.MinDistC2C) / (rondelica.Radius * 2 + rondelica.MinDistC2C);
            int cylindersPerColumn = (Width - rondelica.MinDistC2Edge * 2 + rondelica.MinDistC2C) / (rondelica.Radius * 2 + rondelica.MinDistC2C);
            int result = cylindersPerLine * cylindersPerColumn;

            if (rondelica.Radius == 0 || Length == 0 || Width == 0)
            {
                result = 0;
            }

            // in some cases where spacing is bigger than length or width
            if (result < 0)
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Calculate max number of cylinders that can be cut from rectangle with triangle pattern method
        /// </summary>
        /// <param name="rondelica"></param>
        /// <returns></returns>
        public int MaxNumberOfCylindersTriangularPattern(Rondelica rondelica)
        {
            // TODO: fix
            // https://math.stackexchange.com/questions/2548513/maximum-number-of-circle-packing-into-a-rectangle
            // http://mathworld.wolfram.com/CirclePacking.html
            // https://en.wikipedia.org/wiki/Circle_packing_in_a_square
            // https://www.engineeringtoolbox.com/circles-within-rectangle-d_1905.html

            /* int nrOfLines = (Width - rondelica.MinDistC2Edge * 2) / (rondelica.Radius);
             int nrOfColumns = (int)Math.Round((Length - rondelica.MinDistC2Edge * 2) / (rondelica.Radius * Math.Sqrt(3)));
             //int nrOfColumns = (Length - rondelica.MinDistC2Edge * 2) / rondelica.Radius;
             nrOfColumns = (Length - rondelica.MinDistC2Edge * 2) / (rondelica.Radius * 2);

             int cylindersPerLine = nrOfLines / 2;
             if (nrOfLines % 2 != 0)
             {
                 cylindersPerLine--;
             }

             int cylindersPerColumn = nrOfColumns;

             int result = cylindersPerLine * cylindersPerColumn;

             int m = (Width / rondelica.Radius - 1) / 2;
             int n = (int)((Length / rondelica.Radius - 2) / Math.Sqrt(3) + 1);

             //result = n * m;*/

            int tempWidth = (Width - rondelica.MinDistC2Edge * 2) / (rondelica.Radius);
            int tempLength = (Length - rondelica.MinDistC2Edge * 2) / (rondelica.Radius);

            int nrOfLines = (int)Math.Round(((tempWidth - 2) / Math.Sqrt(3)) + 1);


            int cylindersPerLine = (Length - rondelica.MinDistC2Edge * 2) / (rondelica.Radius * 2);
            int cylindersPerColumn = Width / (rondelica.Radius * 2);

            int result = cylindersPerLine * nrOfLines;
            if (rondelica.Radius == 0 || Length == 0 || Width == 0)
            {
                result = 0;
            }

            // in some cases where spacing is bigger than length or width
            if (result < 0)
            {
                result = 0;
            }

            return result;
        }
    }
}
