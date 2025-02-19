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
            // could have a difficulty rating which increases the amount of monsters that the player must fight
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = false;
            int[] roomSize = new int[2] { 7, 9 }; //This should be viewed as room area, with +2 to each axis
            int doorPosition = 5; // The door is always placed at the top of the room. Door Position controls the horizontal position
            int[] monsterCoord = new int[2] { 3, 5 }; // Setting to -1,-1 indicates no monster
            int[] treasureCoord = new int[2] { 3, 2 }; // Setting to -1,-1 indicates no treasure
            Room r = new Room("first", roomSize, doorPosition, monsterCoord, treasureCoord);
            while (playing)
            {
                // Let's create a game where the player needs to fight monsters in multiple rooms before completing the game to find a treasure in the final room
                // Each room has one monster which the player much fight before the door to the next room is unlocked
                // The player can pick up different types of weapons- these will affect his damage to the monster
                // The player must also manage their health bar, the monster can defend against attacks
            }
        }
    }
}