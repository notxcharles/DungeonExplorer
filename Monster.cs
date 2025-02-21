using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Monster
    {
        public string Name { get; private set; }
        public string Breed { get; private set; }
        public int Health { get; private set; }
        public int AverageAttackDamage { get; private set; }
        private Random m_random;
        public Monster(string name, string breed, int health, int averageAttack)
        {
            Name = name;
            Breed = breed;
            Health = health;
            AverageAttackDamage = averageAttack;
            m_random = new Random();
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
            double multiplier = CreateRandomGaussianNumber(AverageAttackDamage, AverageAttackDamage / stdDevPercentage);
            int attackDamage = Convert.ToInt32(AverageAttackDamage * multiplier);
            return attackDamage;
        }
    }
}
