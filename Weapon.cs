using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Weapon
    {
        public string Type { get; private set; }
        public int AverageDamage { get; private set; }
        Random m_random;
        private string[] weaponTypes = {
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
        public Weapon(string type, int weaponAverageDamage)
        {
            m_random = new Random();
            Type = type;
            AverageDamage = weaponAverageDamage;
        }
        public Weapon(int weaponAverageDamage)
        {
            m_random = new Random();
            Type = GetWeaponType();
            AverageDamage = weaponAverageDamage;
        }
        private string GetWeaponType()
        {
            int index = m_random.Next(0, weaponTypes.Length);
            Thread.Sleep(25); //Add a little Thread.Sleep() so that Random can be more pseudorandom
            return weaponTypes[index];
        }
        private double CreateRandomGaussianNumber(int mean, int stdDev)
        {
            double u1 = 1.0 - m_random.NextDouble(); //uniform(0,1) random doubles
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
            double multiplier = CreateRandomGaussianNumber(AverageDamage, AverageDamage / stdDevPercentage);
            int attackDamage = Convert.ToInt32(AverageDamage * multiplier);
            return attackDamage;
        }
        public string CreateSummary()
        {
            string summary = ($"{Type}, dealing an average of {AverageDamage} per attack");
            return summary;
        }
    }
}
