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
            int[] roomSize = new int[2] { 7, 9 }; //This should be viewed as room area, with +2 to each axis
            int doorPosition = 5; // The door is always placed at the top of the room. Door Position controls the horizontal position
            int[] monsterCoord = new int[2] { 2, 3 };
            int[] treasureCoord = new int[2] { 5, 4 };
            Room r = new Room("first", roomSize, doorPosition, monsterCoord, treasureCoord);
            while (playing)
            {
                // Code your playing logic here
                
            }
        }
    }
}