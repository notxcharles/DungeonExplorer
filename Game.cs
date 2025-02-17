using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player

        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = false;
            int[] roomSize = new int[2] { 5, 7 };
            int[] doorCoord = new int[2] { 0, 5 };
            int[] monsterCoord = new int[2] { 2, 3 };
            int[] treasureCoord = new int[2] { 5, 4 };
            Room r = new Room("first", roomSize, doorCoord, monsterCoord, treasureCoord);
            while (playing)
            {
                // Code your playing logic here
                
            }
        }
    }
}