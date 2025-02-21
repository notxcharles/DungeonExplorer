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
        private string[] m_roomNames = new string[] {
            "The Forgotten Hall",
            "Chamber of Chains",
            "The Damp Passage",
            "Fungi Cavern",
            "Banquet Ruins",
            "Statue Gallery",
            "Suspended Bridge",
            "Cathedral of Glass",
            "The Breathing Tunnel",
            "Iron Threshold",
            "The Slime Stairs",
            "Shattered Mirrors",
            "Frozen Abyss",
            "Silent Library",
            "Sunken Temple",
            "Vine Maze",
            "Chain Chamber",
            "Shifting Carvings",
            "Bone Pit",
            "The Still Lake"
        };
        private string[] m_roomDescriptions = new string[] {
            "A vast hall with towering stone pillars, their surfaces worn smooth by time. The air is thick with the scent of damp stone and something faintly metallic.",
            "A circular chamber, its walls lined with rusted chains and shattered weapons. Deep gouges in the floor hint at past struggles.",
            "A long, narrow corridor with an uneven floor, slick with moisture. Faint echoes of dripping water make it impossible to tell how deep the darkness ahead goes.",
            "A cavernous space where bioluminescent fungi cling to the walls, casting eerie blue-green light over jagged rock formations and pools of unknown liquid.",
            "A ruined banquet hall, its wooden tables long rotted, the remnants of a feast petrified in time. The scent of decay lingers despite the ages that have passed.",
            "A chamber filled with strange statues, each frozen in a pose of terror or agony. Their blank eyes seem to follow anyone who enters.",
            "A narrow bridge suspended over a chasm, the ropes frayed and the planks slick with something dark and unidentifiable.",
            "A grand cathedral-like space, where shattered stained glass windows cast fractured light across an altar covered in old, dried stains.",
            "A twisting tunnel with walls that pulse ever so slightly, as if breathing. The ground beneath is soft, like flesh rather than stone.",
            "A massive iron door stands ajar, revealing a cold, metallic room with grated floors. The scent of rust and something acrid fills the air.",
            "A spiral staircase leading downward, its steps uneven and slick with slime. The deeper one descends, the more the walls seem to close in.",
            "A desolate chamber with cracked mirrors covering every surface, each reflecting something just slightly... off.",
            "A frozen cavern where jagged icicles hang from the ceiling, the floor slick and treacherous. The air bites at exposed skin, and breath comes out in thick clouds.",
            "A grand library, its shelves stretching impossibly high. Books lie scattered, some pages torn, others missing entirely. The silence is absolute.",
            "A sunken ruin, half submerged in murky water. Columns rise from the depths, their bases lost in the abyss below.",
            "A maze of twisting roots and gnarled vines, the ground covered in thick, choking fog that swirls unnaturally at the slightest movement.",
            "A towering chamber where chains hang from the ceiling, some swaying ever so slightly despite the lack of any breeze.",
            "A forgotten temple, its walls covered in ancient carvings, some depicting scenes that seem to shift when not directly observed.",
            "A pit of bones, some yellowed with age, others still fresh. The walls are scratched, as if something has tried—and failed—to escape.",
            "A vast underground lake, the water impossibly still. Jagged rocks rise from the surface like teeth, and something beneath the water disturbs the reflection."
        };

        public Game(string gameName, int amountOfRooms, Player player)
        {
            m_gameName = gameName;
            m_numberOfRooms = amountOfRooms;
            m_player = player;
            // Initialize the game with one room and one player
            m_random = new Random();
        }
        public string GetRoomName()
        {
            int index = m_random.Next(0, m_roomNames.Length);
            return m_roomNames[index];
        }
        public string GetRoomDescription()
        {
            int index = m_random.Next(0, m_roomDescriptions.Length);
            return m_roomDescriptions[index];
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
                string roomName = GetRoomName();
                string roomDescription = GetRoomDescription();
                int roomX = m_random.Next(5, 12) + 2;
                int roomY = m_random.Next(4, 10) + 2;
                int doorPosition = roomY - 2; // The door is always placed at the top of the room. Door Position controls the horizontal position
                int[] monsterCoord = new int[2] { 3, 5 }; // Setting to -1,-1 indicates no monster
                int[] roomDimensions = new int[2] { roomX, roomY }; //This should be viewed as room area, with +2 to each axis
                Room currentRoom = new Room(roomName, roomDescription, roomDimensions, doorPosition, currentMonster, monsterCoord);
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