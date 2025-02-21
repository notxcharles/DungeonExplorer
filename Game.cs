using System;
using System.Media;
using System.Threading;

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
            m_random = new Random();
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
                //if (roomNumber == m_numberOfRooms-1)
                //{
                //    //Last room, only this room will contain treasure
                //    Console.WriteLine("Treasure room");
                //    int[] treasureCoord = new int[2] { 3, 2 }; // Setting to -1,-1 indicates no treasure
                //}
                //else
                //{
                //    Console.WriteLine("Regular room");
                //}
                
                
                //monsterCoord and treasureCoord assume that the bottom left tile is at (0,0)
                Monster currentMonster = new Monster(100, 20);
                int roomX = m_random.Next(5, 12) + 2; //Adding 2 so that the walls inside are accounted for
                int roomY = m_random.Next(4, 10) + 2;
                int[] roomDimensions = new int[2] { roomX, roomY }; //This should be viewed as room area, with +2 to each axis
                int doorPosition = m_random.Next(5, roomX) - 2; // The door is always placed at the top of the room. Door Position controls the horizontal position
                int monsterX = m_random.Next(1, roomX-2); //monsterX can take the value that the room's x could be
                int monsterY = m_random.Next(3, roomY-2); //monsterY must be at least 2 away from the bottom most wall
                int[] monsterCoords = new int[2] { monsterX, monsterY }; // Setting to -1,-1 indicates no monster
                Room currentRoom = new Room(roomDimensions, doorPosition, currentMonster, monsterCoords);
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
                    roomNumber += 1;
                }
                else if (decision == 2)
                {
                    //Player wants to goes to next room
                    if (NextRoom(currentRoom))
                    {
                        Thread.Sleep(3500);
                        roomNumber += 1;
                        continue;
                    }
                }

                Thread.Sleep(3600);
                ClearConsole();
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
        public bool NextRoom(Room room)
        {
            if (room.doorIsLocked == false)
            {
                Console.WriteLine("The door is unlocked. You proceed to the next room. . .");
                return true;
            }
            Console.WriteLine("The door is locked! Have you defeated the monster?");
            return false;
        }
        public void FinishGame()
        {
            throw new NotImplementedException();
            return;
        }
    }
}