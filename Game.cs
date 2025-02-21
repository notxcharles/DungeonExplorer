using System;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private string m_gameName;
        private Player m_player;
        private Room m_currentRoom;
        private int m_numberOfRooms;
        private Random m_random;
        public Game(string gameName, int amountOfRooms, Player player)
        {
            m_gameName = gameName;
            m_numberOfRooms = amountOfRooms;
            m_player = player;
            // Initialize the game with one room and one player
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            int roomNumber = 0;
            GameStartDisplay();
            
            while (roomNumber < m_numberOfRooms)
            {
                // Let's create a game where the player needs to fight monsters in multiple rooms before completing the game to find a treasure in the final room
                // Each room has one monster which the player much fight before the door to the next room is unlocked
                // The player can pick up different types of weapons- these will affect his damage to the monster
                // The player must also manage their health bar, the monster can defend against attacks
                int[] roomSize = new int[2] { 7, 9 }; //This should be viewed as room area, with +2 to each axis
                int doorPosition = 5; // The door is always placed at the top of the room. Door Position controls the horizontal position
                int[] monsterCoord = new int[2] { 3, 5 }; // Setting to -1,-1 indicates no monster
                int[] treasureCoord = new int[2] { 3, 2 }; // Setting to -1,-1 indicates no treasure
                //monsterCoord and treasureCoord assume that the bottom left tile is at (0,0)
                Monster currentMonster = new Monster("Dennis", "electric car", 100, 50);
                Room currentRoom = new Room("first", "first room desc", roomSize, doorPosition, currentMonster, monsterCoord);
                currentRoom.WelcomePlayer();
                //while: Player can make multiple decisions whilst in the same room, eg view their inventory, then fight, then go to the next room
                int decision = m_player.GetDecision();
                if (decision == 0)
                {
                    //Player wants to view inventory
                    m_player.ViewInventory();
                }
                else if (decision == 1)
                {
                    //Player wants to fight
                    //Monster monster = room.GetMonster();
                    //m_player.Fight(monster);
                    //There needs to be a monster class that contains the hp and the defence and attacking strength
                    //We can calculate the player attack and defense strength using the Player Class
                    //After defeating the monster, the player has the option to pick up and equip a new 
                }
                else if (decision == 2)
                {
                    //Player wants to goes to next room
                    m_player.NextRoom();
                    //Player can only use the door when the monster is defeated
                }


                roomNumber += 1;
            }
            // Once the player has defeated all of the rooms, the last room will have the treasure
            // When the player retrieves the loot they have won the game
            FinishGame();
            return;
        }
        public void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            return;
        }
        public void GameStartDisplay()
        {
            ClearConsole();
            Console.WriteLine($"Welcome to {m_gameName}");
            Console.WriteLine("Press any key to start the game. . .");
            Console.ReadKey();
            ClearConsole();
            return;
        }
        public void FinishGame()
        {
            throw new NotImplementedException();
            return;
        }
    }
}