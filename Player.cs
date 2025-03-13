using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Player</c> controls the logic of the Player character
    /// </summary>
    public class Player
    {
        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public int Health { get; set; }
        private List<Weapon> _inventory = new List<Weapon>();
        public int MaxInventorySpace { get; private set; }
        private Weapon _currentEquippedWeapon;
        /// <summary>
        /// Class <c>Player</c>'s constructor
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="health">Player's max health</param>
        public Player(string name, int health) 
        {
            Debug.Assert(name != null && name.Length > 0, "Error: Player name is null or string is empty");
            Testing.TestForPositiveInteger(health);
            Name = name;
            MaxHealth = health;
            Health = health;
            MaxInventorySpace = 4;
            //The player's default starting weapon are their fists
            _currentEquippedWeapon = new Weapon("Fists", 30);
        }
        /// <summary>
        /// Class <c>Player</c>'s constructor
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="health">Player's max health</param>
        /// <param name="maxInventorySpace">The maximum inventory space of the player. 0-9</param>
        public Player(string name, int health, int maxInventorySpace)
        {
            Debug.Assert(name != null && name.Length > 0, "Error: Player name is null or string is empty");
            Testing.TestForPositiveInteger(health);
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
        /// <summary>
        /// Player can <c>PickUpItem</c>
        /// </summary>
        /// <remarks>
        /// This function first checks if the Player's inventory is full. If not, it adds \weapon\ to the Player's inventory.
        /// It can be renamed to PickUpWeapon(), however because of the assessment requirements I have renamed it back to
        /// PickUpItem()
        /// </remarks>
        /// <param name="weapon">The weapon that the player will pick up</param>
        public void PickUpItem(Weapon weapon)
        {
            Debug.Assert(MaxInventorySpace <= 9, "Error: MaxInventorySpace should not be greater than 9");
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
        /// <summary>
        /// Handles the logic for the player to equip a different weapon
        /// </summary>
        /// <param name="weaponIndex">The index of the weapon within the player's inventory</param>
        public void EquipDifferentWeapon(int weaponIndex)
        {
            // Swap the selected weapon with the currently equipped weapon
            Weapon weaponToEquip = _inventory[weaponIndex];
            Debug.Assert(weaponToEquip != null, "Error: weaponToEquip is null");
            _inventory.Remove(weaponToEquip);
            _inventory.Add(_currentEquippedWeapon);
            Weapon previousEquippedWeapon = _currentEquippedWeapon;
            _currentEquippedWeapon = weaponToEquip;
            Console.WriteLine($"{_currentEquippedWeapon.Type} has been equipped. " +
                $"{previousEquippedWeapon.Type} has been added to your inventory");
            return;
        }
        /// <summary>
        /// Prints multiple lines to the console displaying information about the Player
        /// </summary>
        /// <remarks>
        /// Shows the Player's health, maximum health and what weapon is currently equipped
        /// </remarks>
        public void ShowCharacterDetails()
        {
            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Equipped Weapon: {_currentEquippedWeapon.CreateSummary()}\n");
            return;
        }
        /// <summary>
        /// <c>ShowTurnDecisions</c> prints all decisions that the Player can make to the console
        /// </summary>
        /// <param name="monsterAlive">true if the Monster's health is greater than 0</param>
        public void ShowTurnDecisions(bool monsterAlive)
        {
            Debug.Assert(!(monsterAlive == true && monsterAlive == false), "Error: monsterAlive was both true and false");
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
        /// <summary>
        /// Call <c>ShowTurnDecisions()</c> and then read the user's input as to the action they choose
        /// </summary>
        /// <remarks>
        /// After the user is shown the decisions that they may make on the turn, this function also returns the integer
        /// value for the decision. The user may only enter an integer, if they do not, they are informed of the required
        /// format and asked for their input again
        /// </remarks>
        /// <param name="monsterAlive">true if the Monster's health is greater than 0</param>
        /// <returns>Int value from 0 to 5 or 9. if monsterAlive = true, 6 may also be returned</returns>
        public int GetTurnDecisions(bool monsterAlive)
        {
            Debug.Assert(!(monsterAlive == true && monsterAlive == false), "Error: monsterAlive was both true and false");
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
                            Console.WriteLine($"{key} was pressed. You must press 0, 1, 2, 3, 4, 5 or 9");
                        }
                    }
                }
                catch (FormatException e)
                {
                    if (monsterAlive)
                    {
                        Console.WriteLine($"{key} was pressed. You must press 0, 1, 2, 3, 4, 5, 6 or 9");
                    }
                    else
                    {
                        Console.WriteLine($"{key} was pressed. You must press 0, 1, 2, 3, 4, 5 or 9");
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// Prints multiple strings of all items in the player's inventory
        /// </summary>
        /// <remarks>
        /// For each item in the Player's inventory, a message is written to the console that displays the item's name.
        /// If the inventory is empty, a message is printed which communicates this to the player instead
        /// </remarks>
        /// <param name="showIndexOfItem">If true, the list index of the item is included in the print</param>
        public void ViewItemsInInventory(bool showIndexOfItem = false)
        {
            Debug.Assert(!(showIndexOfItem == true && showIndexOfItem == false), "Error: showIndexOfItem was both true and false");
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
        /// <summary>
        /// Call <c>ViewItemsInInventory(true)</c> and then read the user's input as to the action they choose
        /// </summary>
        /// <returns>The integer index of the item in _inventory that the user selects</returns>
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
        /// <summary>
        /// <c>GetTotalItemsInInventory()</c> returns a count of the player's total inventory
        /// </summary>
        /// <returns><c>Player._inventory.Count</c></returns>
        public int GetTotalItemsInInventory()
        {
            Debug.Assert(_inventory != null, "Error: Inventory doesn't exist");
            return _inventory.Count;
        }
        /// <summary>
        /// <c>GetCurrentAttackDamage()</c> returns a the damage of the Player's equipped weapon
        /// </summary>
        /// <returns><c>Player._currentEquippedWeapon.GetAttackDamage()</c></returns>
        public int GetCurrentAttackDamage()
        {
            int attackDamage = _currentEquippedWeapon.GetAttackDamage();
            Testing.TestForPositiveInteger(attackDamage);
            return attackDamage;
        }
    }
}
