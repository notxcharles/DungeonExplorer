using System;
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
        private Random m_random;
        private string[] m_monsterNames = new string[] {
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
        private string[] m_monsterBreeds = new string[] {
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
            m_random = new Random();
        }
        public Monster(int health, int averageAttack)
        {
            m_random = new Random();
            Name = GetMonsterName();
            Breed = GetMonsterBreed();
            Health = health;
            MaxHealth = health;
            AverageAttackDamage = averageAttack;
            
        }
        private string GetMonsterName()
        {
            int index = m_random.Next(0, m_monsterNames.Length);
            Thread.Sleep(25); //Add a little Thread.Sleep() so that Random can be more pseudorandom
            return m_monsterNames[index];
        }
        private string GetMonsterBreed()
        {
            int index = m_random.Next(0, m_monsterBreeds.Length);
            Thread.Sleep(25); //Add a little Thread.Sleep() so that Random can be more pseudorandom
            return m_monsterBreeds[index];
        }
        private double CreateRandomGaussianNumber(int mean, int stdDev)
        {
            double u1 = 1.0 - m_random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - m_random.NextDouble();
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
