using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
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

        public int MaxNumberOfCylindersRecPattern(Rondelica r)
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
                        x = (diameter / 2) + spaceToCylinder;
                        y += diameter + spaceToCylinder;
                    } while (y + (diameter / 2) + spaceToWalls <= Width);
                }
            }
            else
            {
                Console.WriteLine("Wrong values");
            }
            ListOfCylinders = listOfCylinders;
            return listOfCylinders.Count;
        }
    }
}
