using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private int[] roomDimensions = new int[2];
        private int doorPosition;
        private int[] monsterCoords = new int[2];
        private int[] treasureCoords = new int[2];
        private char[,] roomDisplay;
        public Room(string description, int[] roomDimensions, int doorPosition, int[] monsterCoordinates, int[] treasureCoordinates)
        {
            this.description = description;
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            this.doorPosition = doorPosition;
            this.monsterCoords = monsterCoordinates;
            this.treasureCoords = treasureCoordinates;

            this.roomDisplay = new char[roomX+2,roomY+2];
            DisplayRoom();
        }

        public string GetDescription()
        {
            return description;
        }

        public int[] GetDimensions()
        {
            return roomDimensions;
        }
        public void DisplayRoom()
        {
            int xMax = roomDimensions[0]+2;
            int yMax = roomDimensions[1]+2;
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
                if (y == 0)
                {
                    line[this.doorPosition] = 'D';
                }
                int monsterX = this.monsterCoords[0];
                int monsterY = this.monsterCoords[1];
                if (y == monsterY)
                {
                    line[monsterX] = 'M';
                }
                int treasureX = this.treasureCoords[0];
                int treasureY = this.treasureCoords[1];
                if (y == treasureY)
                {
                    line[treasureX] = 'T';
                }
                string sLine = String.Join(" ", line);
                Console.WriteLine(sLine);
            }
        }

    }
}