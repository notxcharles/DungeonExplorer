﻿using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {

        }
        public int GetDecision()
        {

            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {this.Health}/100");
            
            bool recievedValidInput = false;
            while (recievedValidInput == false)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("(0) View Inventory");
                Console.WriteLine("(1) Attack Monster");
                Console.WriteLine("(2) Open the door");
                Console.WriteLine("(9) Exit game");
                ConsoleKeyInfo key = Console.ReadKey();
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt == 0 || keyAsInt == 1 || keyAsInt == 2)
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
                        Console.WriteLine($"{key} was pressed. You must press 0, 1, 2 or 9");
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
            if (inventory.Count == 0)
            {
                Console.WriteLine("You have no items in your inventory");
            }
            else
            {
                Console.WriteLine($"Items in your inventory:");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"- {inventory[i]}");
                }
            }

            return;
        }
    }
}