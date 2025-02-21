using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Weapon
    {
        public string Type { get; private set; }
        public int AverageDamage { get; private set; }
        Random m_random;
        public Weapon(string weaponType, int weaponAverageDamage)
        {
            m_random = new Random();
            Type = weaponType;
            AverageDamage = weaponAverageDamage;
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
            double multiplier = CreateRandomGaussianNumber(AverageDamage, AverageDamage / stdDevPercentage);
            int attackDamage = Convert.ToInt32(AverageDamage * multiplier);
            return attackDamage;
        }
    }
}
