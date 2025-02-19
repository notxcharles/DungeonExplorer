using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private int[] roomDimensions;
        private int doorPosition;
        private int[] monsterCoords;
        private int[] treasureCoords;
        private char[,] roomDisplay;
        private bool isTreasure = true;
        private bool doorIsLocked = true;

        // Room that features a monster, exit door and treasure
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
            RenderRoom();
            DisplayRoom();
        }
        // A monster and an exit door in this room
        public Room(string description, int[] roomDimensions, int doorPosition, int[] monsterCoordinates)
        {
            
            this.description = description;
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            this.doorPosition = doorPosition;
            this.monsterCoords = monsterCoordinates;
            this.roomDisplay = new char[roomX + 2, roomY + 2];
            RenderRoom();
            DisplayRoom();
        }
        // The final room, there is treasure in this room but no door or monster
        public Room(string description, int[] roomDimensions, int[] treasureCoordinates)
        {

            this.description = description;
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            this.treasureCoords = treasureCoordinates;
            this.roomDisplay = new char[roomX + 2, roomY + 2];
            RenderRoom();
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

        //Displays the contents of this.roomDisplay to the console
        public void DisplayRoom()
        {
            int yMax = this.roomDisplay.GetLength(1);
            for (int y = 0; y < yMax; y++) 
            {
                char[] line = new char[this.roomDisplay.GetLength(0)];
                int xMax = this.roomDisplay.GetLength(0);
                for (int x = 0; x < xMax; x++)
                {
                    //Console.WriteLine($"{x}, {y}");
                    line[x] = this.roomDisplay[x, y];
                }
                Console.WriteLine(line);
            }
            return;
        }

        //Renders the room and fills out the this.roomDisplay 2d array
        public void RenderRoom()
        {
            int xMax = roomDimensions[0];
            int yMax = roomDimensions[1];
            //Console.WriteLine($"Room of size x={xMax}, y={yMax}:");
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    if ((y == 0 && x == 0) || (y == yMax - 1 && x == xMax - 1))
                    {
                        this.roomDisplay[x, y] = '/';
                    }
                    else if ((y == yMax - 1 && x == 0) || (y == 0 && x == xMax - 1))
                    {
                        this.roomDisplay[x, y] = '\\';
                    }
                    else if (y == 0 || y == yMax - 1)
                    {
                        this.roomDisplay[x, y] = '-';
                    }
                    else if (x == 0 || x == xMax - 1)
                    {
                        this.roomDisplay[x, y] = '|';
                    }
                    else
                    {
                        this.roomDisplay[x, y] = 'o';
                    }
                }
                // Doors, Monsters and Treasures
                if (y == 0)
                {
                    this.roomDisplay[this.doorPosition, y] = 'D';
                }
                int monsterX = this.monsterCoords[0];
                int monsterY = this.monsterCoords[1];
                if (y == monsterY)
                {
                    this.roomDisplay[monsterX, y] = 'M';
                }
                int treasureX = this.treasureCoords[0];
                int treasureY = this.treasureCoords[1];
                if (y == treasureY)
                {
                    this.roomDisplay[treasureX, y] = 'T';
                }
            }
            return;
        }

    }
}