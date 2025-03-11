using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Weapon</c> controls the logic of the Weapon
    /// </summary>
    /// <remarks>
    /// Contains the logic for creating a weapon object that the player can use to attack the monster. Class contains the
    /// type of the weapon, the average attack damage of the weapon, and the method to get calculate the attack damage.
    /// </remarks>
    public class Weapon
    {
        public string Type { get; private set; }
        public int AverageAttackDamage { get; private set; }
        private static Random _random = new Random();
        private static string[] _weaponTypes = {
            "Baseball Bat",
            "Machete",
            "Crowbar",
            "Fire Axe",
            "Katana",
            "Shovel",
            "Chainsaw",
            "Hammer",
            "Shotgun",
            "Rifle",
            "Bow and Arrow",
            "Chair Leg",
            "Fire Extinguisher",
            "Heavy Flashlight",
            "Screwdriver",
            "Kitchen Knife",
            "Barbed Wire",
            "Handheld Lawnmower",
            "Car",
            "Fireworks",
            "Tennis Ball Machine"
        };
        private const int _StdDevPercentage = 5;
        /// <summary>
        /// Class <c>Weapon</c>'s constructor
        /// </summary>
        /// <param name="type">The type of the weapon</param>
        /// <param name="weaponAverageDamage">The weapon's average attack damage</param>
        public Weapon(string type, int weaponAverageDamage)
        {
            Debug.Assert(type != null, "Error: type is null");
            Testing.TestForPositiveInteger(weaponAverageDamage);
            Type = type;
            AverageAttackDamage = weaponAverageDamage;
        }
        /// <summary>
        /// Class <c>Weapon</c>'s constructor
        /// </summary>
        /// <param name="weaponAverageDamage">The weapon's average attack damage</param>
        public Weapon(int weaponAverageDamage)
        {
            _random = new Random();
            Testing.TestForPositiveInteger(weaponAverageDamage);
            Type = CreateWeaponType();
            AverageAttackDamage = weaponAverageDamage;
        }
        /// <summary>
        /// From <c>Weapon._weaponTypes</c>, randomly select a name for the monster
        /// </summary>
        /// <returns>The selected string from Weapon._weaponTypes</returns>
        private string CreateWeaponType()
        {
            // Select a random weapon type based on a list of preselected types
            int index = _random.Next(0, _weaponTypes.Length);
            return _weaponTypes[index];
        }
        /// <summary>
        /// Create a random number from a Gaussian distribution
        /// </summary>
        /// <param name="mean">Mean of the Gaussian distribution</param>
        /// <param name="stdDev">Standard deviation of the distribution</param>
        /// <returns>The random value from the distribution</returns>
        private double CreateRandomGaussianNumber(int mean, int standardDeviation)
        {
            Testing.TestForPositiveInteger(mean);
            Testing.TestForZeroOrAbove(standardDeviation);
            // Returns a random integer, based on a Gaussian distribution
            double u1 = 1.0 - _random.NextDouble(); 
            double u2 = 1.0 - _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = mean + standardDeviation * randStdNormal;
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
            // The damage of the weapon is based of a gaussian distribution so the damage can vary
            // AverageAttack represents the mean of a normal distribution
            double attackDamageGaussian = CreateRandomGaussianNumber(AverageAttackDamage, AverageAttackDamage / _StdDevPercentage);
            int attackDamage = Convert.ToInt32(attackDamageGaussian);
            Testing.TestForPositiveInteger(attackDamage);
            return attackDamage;
        }
        /// <summary>
        /// Create the summary of the weapon
        /// </summary>
        /// <remarks>
        /// The summary contains the type of the weapon and the average attack damage of the weapon.
        /// </remarks>
        /// <returns>The summary</returns>
        public string CreateSummary()
        {
            string summary = ($"{Type}, dealing an average of {AverageAttackDamage} per attack");
            Debug.Assert(summary != null || summary.Length > 0, "Error: Summary is null or empty");
            return summary;
        }
    }
}
