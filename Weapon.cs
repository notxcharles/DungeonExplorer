using System;

namespace DungeonExplorer
{
    public class Weapon
    {
        public string Type { get; private set; }
        public int AverageAttackDamage { get; private set; }
        private static Random m_random = new Random();
        private string[] m_weaponTypes = {
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
        private const int stdDevPercentage = 5;
        public Weapon(string type, int weaponAverageDamage)
        {
            Type = type;
            AverageAttackDamage = weaponAverageDamage;
        }
        public Weapon(int weaponAverageDamage)
        {
            m_random = new Random();
            Type = CreateWeaponType();
            AverageAttackDamage = weaponAverageDamage;
        }
        private string CreateWeaponType()
        {
            int index = m_random.Next(0, m_weaponTypes.Length);
            return m_weaponTypes[index];
        }
        private double CreateRandomGaussianNumber(int mean, int standardDeviation)
        {
            double u1 = 1.0 - m_random.NextDouble(); 
            double u2 = 1.0 - m_random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = mean + standardDeviation * randStdNormal;
            return randNormal;
        }
        public int GetAttackDamage()
        {
            //AverageAttack represents the mean of a normal distribution
            double attackDamageGaussian = CreateRandomGaussianNumber(AverageAttackDamage, AverageAttackDamage / stdDevPercentage);
            //attackDamage will be a random integer datapoint in the distribution
            int attackDamage = Convert.ToInt32(attackDamageGaussian);
            return attackDamage;
        }
        public string CreateSummary()
        {
            string summary = ($"{Type}, dealing an average of {AverageAttackDamage} per attack");
            return summary;
        }
    }
}
