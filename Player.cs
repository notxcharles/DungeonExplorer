using System;
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
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
        public int GetDecision()
        {
            throw new NotImplementedException();
            return 0;
        }

        public void ViewInventory()
        {
            throw new NotImplementedException();
            return;
        }
        public void NextRoom()
        {
            //check if the player is allowed to go to the next room
            throw new NotImplementedException();
            return;
        }
    }
}