using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public int Health { get; set; }
        private List<Weapon> _inventory = new List<Weapon>();
        public int MaxInventorySpace { get; private set; }
        private Weapon _currentEquippedWeapon;
        public Player(string name, int health) 
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            MaxInventorySpace = 4;
            //The player's default starting weapon are their fists
            _currentEquippedWeapon = new Weapon("Fists", 30);
        }
        public Player(string name, int health, int maxInventorySpace)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            // There needs to be a maximum inventory space so that ChangeEquippedWeapon() can work
            if (maxInventorySpace > 9)
            {
                maxInventorySpace = 9;
            }
            this.MaxInventorySpace = maxInventorySpace;
            //The player's default starting weapon are their fists
            _currentEquippedWeapon = new Weapon("Fists", 30);
        }
        public void PickUpWeapon(Weapon weapon)
        {
            if (_inventory.Count == MaxInventorySpace)
            {
                Console.WriteLine("Your inventory is full! You cannot pick up any more weapons");
            }
            else if (weapon == null)
            {
                Console.WriteLine("Error: Weapon does not exist");
            }
            else
            {
                _inventory.Add(weapon);
                Console.WriteLine($"{weapon.Type} has been added to your inventory");
            }
            return;
        }
        public void EquipDifferentWeapon(int weaponIndex)
        {
            // Swap the selected weapon with the currently equipped weapon
            Weapon weaponToEquip = _inventory[weaponIndex];
            _inventory.Remove(weaponToEquip);
            _inventory.Add(_currentEquippedWeapon);
            Weapon previousEquippedWeapon = _currentEquippedWeapon;
            _currentEquippedWeapon = weaponToEquip;
            Console.WriteLine($"{_currentEquippedWeapon.Type} has been equipped. " +
                $"{previousEquippedWeapon.Type} has been added to your inventory");
            return;
        }

        public void ShowCharacterDetails()
        {
            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Equipped Weapon: {_currentEquippedWeapon.CreateSummary()}\n");
            return;
        }
        public void ShowTurnDecisions(bool monsterAlive)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("(0) View Inventory");
            Console.WriteLine("(1) Change Equipped Item");
            Console.WriteLine("(2) Pick up weapon");
            Console.WriteLine("(3) Retreat and heal");
            Console.WriteLine("(4) Open the door");
            Console.WriteLine("(5) View room name and description again");
            if (monsterAlive)
            {
                Console.WriteLine($"(6) Attack Monster with {_currentEquippedWeapon.Type}");
            }
            
            Console.WriteLine("(9) Exit game");
            return;
        }
        public int GetTurnDecisions(bool monsterAlive)
        {
            ShowCharacterDetails();
            bool recievedValidInput = false;
            while (recievedValidInput == false)
            {
                ShowTurnDecisions(monsterAlive);
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine("");
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= 0 && keyAsInt <= 6)
                    {
                        Console.WriteLine($"Player pressed {keyAsInt}");
                        return keyAsInt;
                    }
                    else if (keyAsInt == 9)
                    {
                        Console.WriteLine($"Player wishes to exit");
                        Environment.Exit(0);
                    }
                    else
                    {
                        if (monsterAlive)
                        {
                            Console.WriteLine($"{key} was pressed. You must press 0, 1, 2, 3, 4, 5, 6 or 9");
                        }
                        else
                        {
                            Console.WriteLine($"{key} was pressed. You must press 0, 1, 2, 3, 4 or 9");
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{key} was pressed. Please press 0, 1, 2 or 9");
                }
            }
            return -1;
        }

        public void ViewItemsInInventory(bool showIndexOfItem = false)
        {
            // If there are no items in the inventory, show an error
            if (_inventory.Count == 0)
            {
                Console.WriteLine("You have no items in your inventory. You can hold up to 4 weapons.");
            }
            else
            {
                Console.WriteLine($"Current equipped weapon: {_currentEquippedWeapon.CreateSummary()}");
                Console.WriteLine($"Items in your inventory:");
                for (int i = 0; i < _inventory.Count; i++)
                {
                    if (showIndexOfItem)
                    {
                        Console.WriteLine($"({i}) {_inventory[i].CreateSummary()}");
                    }
                    else
                    {
                        Console.WriteLine($"- {_inventory[i].CreateSummary()}");
                    }     
                }
                Console.WriteLine($"You can hold up to {MaxInventorySpace} weapons in your inventory. You " +
                    $"are currently holding {_inventory.Count} weapons.");                
            }
            return;
        }
        public int SelectWeaponInInventory()
        {
            ViewItemsInInventory(true);
            // Player can't select an item in their inventory if their inventory is empty
            if (_inventory.Count == 0)
            {
                return -1;
            }
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= 0 && keyAsInt < _inventory.Count)
                    {
                        return keyAsInt;
                    }
                    else
                    {
                        Console.WriteLine($"{key} was pressed. You must press a key that " +
                            $"corresponds to a weapon");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{key} was pressed. You may only press a key that " +
                        $"corresponds to a weapon");
                }
            }
        }
        public int GetTotalItemsInInventory()
        {
            return _inventory.Count;
        }
        public int GetCurrentAttackDamage()
        {
            return _currentEquippedWeapon.GetAttackDamage();
        }
    }
}