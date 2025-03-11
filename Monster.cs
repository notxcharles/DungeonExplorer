using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Player</c> controls the logic of the Monster
    /// </summary>
    /// <remarks>
    /// The <c>Monster</c> class is used to create a monster object that the player will fight against.
    /// </remarks>
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

        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="name">The name of the monster</param>
        /// <param name="breed">The breed of the monster</param>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(string name, string breed, int health, int averageAttack)
        {
            Debug.Assert(name != null, "Error: name does not exist");
            Debug.Assert(breed != null, "Error: breed does not exist");
            Testing.TestForPositiveInteger(health);
            Testing.TestForZeroOrAbove(averageAttack);
            Name = name;
            Breed = breed;
            Health = health;
            MaxHealth = health;
            AverageAttackDamage = averageAttack;
        }
        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(int health, int averageAttack)
        {
            Name = CreateMonsterName();
            Breed = CreateMonsterBreed();
            Testing.TestForPositiveInteger(health);
            Testing.TestForZeroOrAbove(averageAttack);
            Health = health;
            MaxHealth = health;
            AverageAttackDamage = averageAttack;
            
        }
        /// <summary>
        /// From <c>Monster._monsterNames</c>, randomly select a name for the monster
        /// </summary>
        /// <returns>The selected string from Monster._monsterNames</returns>
        private string CreateMonsterName()
        {
            int index = _random.Next(0, _monsterNames.Length);
            return _monsterNames[index];
        }
        /// <summary>
        /// From <c>Monster._monsterBreeds</c>, randomly select a name for the monster
        /// </summary>
        /// <returns>The selected string from Monster._monsterBreeds</returns>
        private string CreateMonsterBreed()
        {
            int index = _random.Next(0, _monsterBreeds.Length);
            return _monsterBreeds[index];
        }
        /// <summary>
        /// Create a random number from a Gaussian distribution
        /// </summary>
        /// <param name="mean">Mean of the Gaussian distribution</param>
        /// <param name="stdDev">Standard deviation of the distribution</param>
        /// <returns>The random value from the distribution</returns>
        private double CreateRandomGaussianNumber(int mean, int stdDev)
        {
            double u1 = 1.0 - _random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal;
        }
        /// <summary>
        /// Get the attack damage of the monster
        /// </summary>
        /// <remarks>
        /// Uses the <c>CreateRandomGaussianNumber()</c> function to get the attack damage that the monster does.
        /// </remarks>
        /// <returns>the attack damage</returns>
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
