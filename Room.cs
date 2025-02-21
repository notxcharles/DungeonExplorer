using System;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        public string roomName { get; private set; }
        public string description { get; private set; }
        public Monster monster { get; private set; }
        public bool doorIsLocked { get; private set; }
        private int[] roomDimensions;
        private int doorPosition;
        private int[] monsterCoords;
        private int[] treasureCoords;
        private char[,] roomDisplay;
        
        private bool isTreasure = true;

        // A monster and an exit door in this room
        public Room(string roomName, string description, int[] roomDimensions, int doorPosition, Monster monster, int[] monsterCoordinates)
        {
            this.roomName = roomName;
            this.description = description;
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            this.doorPosition = doorPosition;
            this.monsterCoords = monsterCoordinates;
            this.monster = monster;
            roomDisplay = new char[roomX + 2, roomY + 2];
            doorIsLocked = true;
            RenderRoom();
        }
        // The final room, there is treasure in this room but no door or monster
        public Room(string roomName, string description, int[] roomDimensions, int[] treasureCoordinates)
        {
            this.roomName = roomName;
            this.description = description;
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            this.treasureCoords = treasureCoordinates;
            this.roomDisplay = new char[roomX + 2, roomY + 2];
            RenderRoom();
        }

        public string GetDescription()
        {
            return description;
        }

        public int[] GetDimensions()
        {
            return roomDimensions;
        }

        private Monster GetMonster()
        {
            return monster;
        }

        //Displays the contents of this.roomDisplay to the console
        public void DisplayRoom()
        {
            int yMax = this.roomDisplay.GetLength(1);
            for (int y = yMax-1; y >= 0; y--) 
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
                if (y == yMax-1)
                {
                    this.roomDisplay[this.doorPosition, y] = 'D';
                }
                if (monsterCoords != null)
                {
                    int monsterX = this.monsterCoords[0];
                    int monsterY = this.monsterCoords[1];
                    if (y == monsterY)
                    {
                        this.roomDisplay[monsterX, y] = 'M';
                    }
                }
                if (treasureCoords != null)
                {
                    int treasureX = this.treasureCoords[0];
                    int treasureY = this.treasureCoords[1];
                    if (y == treasureY)
                    {
                        this.roomDisplay[treasureX, y] = 'T';
                    }
                }
            }
            return;
        }
        public void WelcomePlayer()
        {
            Console.WriteLine($"Welcome to room {this.roomName}");
            Console.WriteLine($"{this.description}");
            if (monster != null)
            {
                Console.WriteLine($"A {monster.Breed} called {monster.Name} is present! It has {monster.Health} health and does an average of {monster.AverageAttackDamage} attack damage!");
            }
            else
            {
                Console.WriteLine($"There is no monster in this room!");
            }
            DisplayRoom();
            return;
        }
    }
}