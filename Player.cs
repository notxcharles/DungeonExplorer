using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public int Health { get; set; }
        private List<Weapon> inventory = new List<Weapon>();
        public int maxInventorySpace { get; private set; }
        private Weapon currentEquippedWeapon;
        public Player(string name, int health) 
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            maxInventorySpace = 4;
            //The player's default starting weapon are their fists
            currentEquippedWeapon = new Weapon("Fists", 30);
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
            this.maxInventorySpace = maxInventorySpace;
            //The player's default starting weapon are their fists
            currentEquippedWeapon = new Weapon("Fists", 30);
        }
        public void PickUpWeapon(Weapon weapon)
        {
            //Check if the inventory is full (we'll say full=4 weapons)-
            if (inventory.Count == maxInventorySpace)
            {
                Console.WriteLine("Your inventory is full! You cannot pick up any more weapons");
            }
            else if (weapon == null)
            {
                Console.WriteLine("Error: Weapon does not exist");
            }
            else
            {
                inventory.Add(weapon);
                Console.WriteLine($"{weapon.Type} has been added to your inventory");
            }
            return;
        }
        public void EquipDifferentWeapon(int weaponIndex)
        {
            Weapon weaponToEquip = inventory[weaponIndex];
            inventory.Remove(weaponToEquip);
            inventory.Add(currentEquippedWeapon);
            Weapon previousEquippedWeapon = currentEquippedWeapon;
            currentEquippedWeapon = weaponToEquip;
            Console.WriteLine($"{currentEquippedWeapon.Type} has been equipped. " +
                $"{previousEquippedWeapon.Type} has been added to your inventory");
            return;
        }

        public void ShowCharacterDetails()
        {
            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Equipped Weapon: {currentEquippedWeapon.CreateSummary()}\n");
        }
        public void ShowTurnDecisions()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("(0) View Inventory");
            Console.WriteLine("(1) Change Equipped Item");
            Console.WriteLine("(2) Pick up weapon");
            Console.WriteLine($"(3) Attack Monster with {currentEquippedWeapon.Type}");
            Console.WriteLine("(4) Retreat and heal");
            Console.WriteLine("(5) Open the door");
            Console.WriteLine("(9) Exit game");
        }
        public int GetTurnDecisions()
        {
            ShowCharacterDetails();
            bool recievedValidInput = false;
            while (recievedValidInput == false)
            {
                ShowTurnDecisions();
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine("");
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= 0 && keyAsInt <= 5)
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
                        Console.WriteLine($"{key} was pressed. You must press 0, 1, 2, 3, 4, 5 or 9");
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
            // if there are items in the inventory, return the number of items
            if (inventory.Count == 0)
            {
                Console.WriteLine("You have no items in your inventory. You can hold up to 4 weapons.");
            }
            else
            {
                Console.WriteLine($"Current equipped weapon: {currentEquippedWeapon.CreateSummary()}");
                Console.WriteLine($"Items in your inventory:");
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (showIndexOfItem)
                    {
                        Console.WriteLine($"({i}) {inventory[i].CreateSummary()}");
                    }
                    else
                    {
                        Console.WriteLine($"- {inventory[i].CreateSummary()}");
                    }     
                }
                Console.WriteLine($"You can hold up to 4 weapons in your inventory. You are currently " +
                    $"holding {inventory.Count} weapons.");                
            }
            return;
        }
        public int SelectWeaponInInventory()
        {
            ViewItemsInInventory(true);
            if (inventory.Count == 0)
            {
                return -1;
            }
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= 0 && keyAsInt < inventory.Count)
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
            return inventory.Count;
        }
        public int GetCurrentAttackDamage()
        {
            return currentEquippedWeapon.GetAttackDamage();
        }
    }
}