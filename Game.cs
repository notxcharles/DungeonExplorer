using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    internal class Game
    {
        private string _gameName;
        private Player _player;
        private Room _currentRoom;
        private int _numberOfRooms;
        private static Random _random = new Random();
        
        public Game(string gameName, int amountOfRooms, Player player)
        {
            Debug.Assert(gameName != null, "Error: gameName is null");
            Debug.Assert(amountOfRooms > 0, "Error: amountOfRooms is less than 1");
            Debug.Assert(player != null, "Error: player is null");
            // Initialize the game with one room and one player
            _gameName = gameName;
            _numberOfRooms = amountOfRooms;
            _player = player;
        }
        public void Start()
        {
            int roomNumber = 0;
            GameStartDisplay();
            _currentRoom = CreateNewRoom();
            while (roomNumber < _numberOfRooms)
            {
                _currentRoom.WelcomePlayer(roomNumber);
                bool isMonsterAlive = _currentRoom.IsMonsterAlive();
                int decision = _player.GetTurnDecisions(isMonsterAlive);
                Debug.Assert(decision >= 0 && decision <= 6, "Error: Decision must be an integer value from 0 to 6");
                if (decision == 0)
                {
                    //Player wants to view inventory
                    _player.ViewItemsInInventory();
                }
                else if (decision == 1)
                {
                    //player has chosen to change their equipped item
                    int weaponChosen = _player.SelectWeaponInInventory();
                    if (weaponChosen == -1)
                    {
                        continue;
                    }
                    _player.EquipDifferentWeapon(weaponChosen);
                }
                else if (decision == 2)
                {
                    //player has chosen to pickup a weapon
                    if (_player.GetTotalItemsInInventory() == _player.MaxInventorySpace)
                    {
                        Console.WriteLine("Your inventory is full, you may not collect any more weapons");
                    }
                    else
                    {
                        _player.PickUpWeapon(_currentRoom.WeaponInTheRoom);
                        _currentRoom.WeaponPickedUp();
                    }
                }
                else if (decision == 3)
                {
                    
                    //Retreat and heal-
                    int healthRecovered = _player.MaxHealth - _player.Health;
                    _player.Health = _player.MaxHealth;
                    Console.WriteLine($"\nYou have stepped back and regained {healthRecovered} health");
                }
                else if (decision == 4)
                {
                    //Player wants to goes to next room
                    if (NextRoom(_currentRoom))
                    {
                        roomNumber += 1;
                        _currentRoom = CreateNewRoom();
                    }
                }
                else if (decision == 5)
                {
                    Console.WriteLine($"You are in {_currentRoom.GetRoomName()}. {_currentRoom.GetDescription()}");
                }
                else if (decision == 6)
                {
                    if (isMonsterAlive)
                    {
                        PlayerFightsMonster(_player, _currentRoom.MonsterInTheRoom, _currentRoom);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! You cannot fight a monster as there is no monster in the room!");
                    }

                }
                PromptNextTurn();
                ClearConsole();
            }
            FinishGame();
            return;
        }
        public void ClearConsole()
        {
            Console.Clear();
            // Ocasionally, Console.Clear() won't completely clear the console, so the following line solves that error
            Console.WriteLine("\x1b[3J");
            return;
        }
        public void GameStartDisplay()
        {
            ClearConsole();
            Console.WriteLine($"Welcome to {_gameName}");
            Console.WriteLine($"You must battle your way through each room. In each room you will have to defeat a " +
                $"monster who will have the the key to unlock the door!");
            Console.WriteLine("Press any key to start the game. . .");
            Console.ReadKey();
            ClearConsole();
            return;
        }
        public Room CreateNewRoom(string roomName = "", string roomDescription = "", int monsterHealth = 100, int monsterDamage = 20)
        {
            Monster currentMonster = new Monster(monsterHealth, monsterDamage);
            int randomDamage = _random.Next(35, 70);
            Weapon weapon = new Weapon(randomDamage);
            if (roomName != "" && roomDescription != "")
            {
                return new Room(roomName, roomDescription, currentMonster);
            }
            return new Room(currentMonster, weapon);
        }
        public void PromptNextTurn()
        {
            Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo key = Console.ReadKey();
        }
        public bool NextRoom(Room room)
        {
            Debug.Assert(room != null, "Error: room is null");
            if (room.DoorIsLocked == false)
            {
                Console.WriteLine("The door is unlocked. You proceed to the next room. . .");
                return true;
            }
            Console.WriteLine("The door is locked! Have you defeated the monster?");
            return false;
        }
        public void PlayerFightsMonster(Player player, Monster monster, Room room)
        {
            Debug.Assert(player != null, "Error: player is null");
            Debug.Assert(monster != null, "Error: monster is null");
            Debug.Assert(room != null, "Error: room is null");
            int playerAttackDamage = player.GetCurrentAttackDamage();
            monster.Health -= playerAttackDamage;
            int monsterAttackDamage = -1;
            if (monster.Health > 0)
            { 
                monsterAttackDamage = monster.GetAttackDamage();
                player.Health -= monsterAttackDamage;
            }
            if (monster.Health <= 0)
            {
                Console.WriteLine($"You have killed the monster! You did {playerAttackDamage} damage. Congratulations!");
                room.MonsterInTheRoom = null;
                room.DoorIsLocked = false;
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine($"The monster has killed you! You took {monsterAttackDamage} damage. Game Over");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine($"You have hit the monster for {playerAttackDamage} damage. " +
                    $"The monster now has {monster.Health}/{monster.MaxHealth}");
                Console.WriteLine($"The monster has hit you for {monsterAttackDamage} damage. " +
                    $"You now have {player.Health}/{player.MaxHealth}");
            }
            Console.WriteLine("here");
            return;
        }
        public void FinishGame()
        {
            Console.WriteLine("Congratulations. You have won! Here is your treasure");
            return;
        }
    }
}