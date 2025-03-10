﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DungeonExplorer
{
    public class Monster
    {
        public string Name { get; private set; }
        public string Breed { get; private set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AverageAttackDamage { get; private set; }
        private static Random _random = new Random();
        private static string[] _monsterNames = new string[] {
            "Walter White",
            "Joffrey Baratheon",
            "Cersei Lannister",
            "Slade Wilson",
            "Draco Malfoy",
            "Tyrion Lannister",
            "Frank Underwood",
            "The Governor",
            "Wilson Fisk",
            "Negan",
            "Pete Campbell",
            "Alaric Saltzman",
            "Dexter Morgan",
            "Tommen Baratheon",
            "Annalise Keating",
            "Jack Torrance",
            "Omar Little",
            "Bane",
            "Regina Mills",
            "Kai Parker",
            "Dennis Reynolds",
            "Darth Maul",
            "Count Dooku",
            "Jabba the Hutt",
        };
        private static string[] _monsterBreeds = new string[] {
            "Goblin",
            "Troll",
            "Werewolf",
            "Vampire",
            "Zombie",
            "Dragon",
            "Skeleton",
            "Ghoul",
            "Banshee",
            "Witch",
            "Demon",
            "Phantom",
            "Hydra",
            "Orc",
            "Minotaur",
            "Kraken",
            "Giant",
            "Hellhound",
            "Ogre",
            "Cyclopes"
        };


        public Monster(string name, string breed, int health, int averageAttack)
        {
            Name = name;
            Breed = breed;
            Health = health;
            MaxHealth = health;
            AverageAttackDamage = averageAttack;
        }
        public Monster(int health, int averageAttack)
        {
            Name = GetMonsterName();
            Breed = GetMonsterBreed();
            Health = health;
            MaxHealth = health;
            AverageAttackDamage = averageAttack;
            
        }
        private string GetMonsterName()
        {
            int index = _random.Next(0, _monsterNames.Length);
            return _monsterNames[index];
        }
        private string GetMonsterBreed()
        {
            int index = _random.Next(0, _monsterBreeds.Length);
            return _monsterBreeds[index];
        }
        private double CreateRandomGaussianNumber(int mean, int stdDev)
        {
            double u1 = 1.0 - _random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal;
        }
        public int GetAttackDamage()
        {
            //m_averageAttack represents the mean of a normal distribution
            //attackDamage will be a random datapoint in the distribution
            int stdDevPercentage = 5;
            double attackDamageGaussian = CreateRandomGaussianNumber(AverageAttackDamage, AverageAttackDamage / stdDevPercentage);
            int attackDamage = Convert.ToInt32(attackDamageGaussian);
            return attackDamage;
        }
    }
}
