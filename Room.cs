using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private int[] dimensions = new int[2];
        private int[] doorCoords = new int[2];
        private int[] monsterCoords = new int[2];
        private int[] treasureCoords = new int[2];
        private char[,] roomDisplay;
        public Room(string description, int[] roomDimensions, int[] doorCoordinates, int[] monsterCoordinates, int[] treasureCoordinates)
        {
            this.description = description;
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.dimensions[0] = roomX;
            this.dimensions[1] = roomY;

            this.roomDisplay = new char[roomX+2,roomY+2];
            DisplayRoom();
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
            int xMax = dimensions[0]+2;
            int yMax = dimensions[1]+2;
            Console.WriteLine($"Room of size x={xMax}, y={yMax}:");
            for (int y = 0; y < yMax; y++)
            {
                char[] line = new char[yMax];
                string[] lines = new string[yMax];
                for (int x = 0; x < xMax; x++)
                {
                    if ((y == 0 && x == 0) || (y == yMax-1 && x == xMax-1))
                    {
                        line[x] = '/';
                    }
                    else if ((y == yMax-1 && x == 0) || (y == 0 && x == xMax-1))
                    {
                        line[x] = '\\';
                    }
                    else if (y == 0 || y == yMax - 1)
                    {
                        line[x] = '-';
                    }
                    else if (x == 0 || x == xMax - 1)
                    {
                        line[x] = '|';
                    }
                    else
                    {
                        line[x] = 'o';
                    }
                }
                // Doors, Monsters and Treasures
                int doorsX = this.doorCoords[0];
                int doorsY = this.doorCoords[1];
                if (y == doorsY)
                {
                    line[doorsX] = 'D';
                }
                int monsterX = this.monsterCoords[0];
                int monsterY = this.monsterCoords[1];
                if (y == doorsY)
                {
                    line[monsterX] = 'M';
                }
                int treasureX = this.treasureCoords[0];
                int treasureY = this.treasureCoords[1];
                if (y == doorsY)
                {
                    line[treasureX] = 'T';
                }
                string sLine = String.Join(" ", line);
                Console.WriteLine(sLine);
            }
        }

    }
}