using System;
using System.Linq;
using System.Threading;

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
        Random m_random;
        // A monster and an exit door in this room
        public Room(string roomName, string description, int[] roomDimensions, int doorPosition, Monster monster, int[] monsterCoordinates)
        {
            m_random = new Random();
            this.roomName = roomName;
            this.description = description;
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            this.doorPosition = doorPosition;
            monsterCoords = monsterCoordinates;
            this.monster = monster;
            roomDisplay = new char[roomX, roomY];
            doorIsLocked = true;
            RenderRoom();
        }
        public Room(int[] roomDimensions, int doorPosition, Monster monster, int[] monsterCoordinates)
        {
            m_random = new Random();
            roomName = GetRoomName();
            description = GetRoomDescription();
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            this.doorPosition = doorPosition;
            monsterCoords = monsterCoordinates;
            this.monster = monster;
            roomDisplay = new char[roomX, roomY];
            doorIsLocked = true;
            RenderRoom();
        }
        // The final room, there is treasure in this room but no door or monster
        public Room(string roomName, string description, int[] roomDimensions, int[] treasureCoordinates)
        {
            m_random = new Random();
            roomName = GetRoomName();
            description = GetRoomDescription();
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            treasureCoords = treasureCoordinates;
            roomDisplay = new char[roomX, roomY];
            RenderRoom();
        }
        public Room(int[] roomDimensions, int[] treasureCoordinates)
        {
            m_random = new Random();
            roomName = GetRoomName();
            description = GetRoomDescription();
            int roomX = roomDimensions[0];
            int roomY = roomDimensions[1];
            this.roomDimensions = roomDimensions;
            treasureCoords = treasureCoordinates;
            roomDisplay = new char[roomX, roomY];
            RenderRoom();
        }
        private string GetRoomName()
        {
            int index = m_random.Next(0, m_roomNames.Length);
            Thread.Sleep(25); //Add a little Thread.Sleep() so that Random can be more pseudorandom
            return m_roomNames[index];
        }
        private string GetRoomDescription()
        {
            int index = m_random.Next(0, m_roomDescriptions.Length);
            Thread.Sleep(25); //Add a little Thread.Sleep() so that Random can be more pseudorandom
            return m_roomDescriptions[index];
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
            int xMax = this.roomDisplay.GetLength(0);
            Console.WriteLine($"This is the room! A height of {xMax - 2} and a height of {yMax - 2}!");
            
            for (int y = yMax-1; y >= 0; y--) 
            {
                char[] line = new char[this.roomDisplay.GetLength(0)];
                
                for (int x = 0; x < xMax; x++)
                {
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
            //Console.WriteLine($"Room of size x={xMax}, y={yMax}, doorpos={doorPosition}:");
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    if ((y == 0 && x == 0) || (y == yMax - 1 && x == xMax - 1))
                    {
                        this.roomDisplay[x, y] = '\\';
                    }
                    else if ((y == yMax - 1 && x == 0) || (y == 0 && x == xMax - 1))
                    {
                        this.roomDisplay[x, y] = '/';
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
                        this.roomDisplay[x, y] = ' ';
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