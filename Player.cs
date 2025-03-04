﻿using System;
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
        public int ShowWeaponsInInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("You have no items in your inventory. You can hold up to 4 weapon(s).");
                return -1;
            }
            else
            {
                while (true)
                {
                    Console.WriteLine($"Items in your inventory:");
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        Console.WriteLine($"({i}) {inventory[i].CreateSummary()}");
                    }
                    Console.WriteLine($"What weapon would you like to equip?");
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
            return -1;
        }
        public int GetDecision()
        {

            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {Health}/100");
            
            bool recievedValidInput = false;
            while (recievedValidInput == false)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("(0) View Inventory");
                Console.WriteLine("(1) Change Equipped Item");
                Console.WriteLine("(2) Pick up weapon");
                Console.WriteLine($"(3) Attack Monster with {currentEquippedWeapon.Type}");
                Console.WriteLine("(4) Retreat and heal");
                Console.WriteLine("(5) Open the door");
                Console.WriteLine("(9) Exit game");
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

        public void ViewInventory()
        {
            // if there are items in the inventory, return the number of items
            if (inventory.Count == 0)
            {
                Console.WriteLine("You have no items in your inventory. You can hold up to 4 weapons.");
            }
            else
            {
                Console.WriteLine($"Items in your inventory:");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"- {inventory[i].CreateSummary()}");
                }
                Console.WriteLine($"You can hold up to 4 weapons in your inventory. You are currently " +
                    $"holding {inventory.Count} weapons.");
            }
            return;
        }
        public int GetTotalItemsInInventory()
        {
            return inventory.Count;
        }
        public int GetAttackDamage()
        {
            return currentEquippedWeapon.GetAttackDamage();
        }
    }
}