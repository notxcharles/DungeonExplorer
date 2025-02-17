using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private int[] dimensions = new int[2];
        private char[,] roomDisplay;
        public Room(string description, int x, int y)
        {
            this.description = description;
            this.dimensions[0] = x;
            this.dimensions[1] = y;
            /* when x = 2; y = 4;
             * [ [], [] ]
             * [ [], [] ]
             * [ [], [] ]
             * [ [], [] ]
             */
            this.roomDisplay = new char[x,y];
            DisplayRoom();
            Console.WriteLine($"{dimensions[0]} , {dimensions[1]}");
        }

        public string GetDescription()
        {
            return description;
        }

        public int[] GetDimensions()
        {
            return dimensions;
        }
        public void DisplayRoom()
        {
            int xMax = dimensions[0];
            int yMax = dimensions[1];
            Console.WriteLine($"Room:");
            for (int x = 0; x < xMax; x++)
            {
                char[] line = new char[yMax];
                for (int y = 0; y < yMax; y++)
                {
                    if ((y == 0 && x == 0) || (y == yMax - 1 && x == xMax- 1))
                    {
                        line[y] = '/';
                    }
                    else if ((y == yMax - 1 && x == 0) || (y == 0 && x == xMax - 1))
                    {
                        line[y] = '\\';
                    }
                    else if (y == 0 || y == yMax - 1)
                    {
                        line[y] = '|';
                    }
                    else if (x == 0 || x == xMax - 1)
                    {
                        line[y] = '-';
                    }
                    else
                    {
                        line[y] = 'o';
                    }
                }
                string sLine = String.Join(" ", line);
                Console.WriteLine(sLine);
            }
        }
    }
}