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
            Room r = new Room("first", 5, 7);
            while (playing)
            {
                // Code your playing logic here
                
            }
        }
    }
}