using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Enemy
    {
        string name;
        int health;
        int damage;
        int level;
        Random rng;

        public Enemy (string name, int health, int damage, int level)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.level = level;
            rng = new Random();
        }

        public void Hurt (int incomingDamage)
        {
            if (health <= 0)
            {
                Console.WriteLine("This enemy is already dead");
                return;
            }
            health = incomingDamage;
            Console.WriteLine("Enemy " + name + " got hurt for " + incomingDamage + " points");
            Console.WriteLine("Enemy health:" + health);
            if (health <= 0)
            {
                Console.WriteLine("Enemy " + name + "is dead.");
            }
        }
        public int Attack()
        {
            return rng.Next(damage / 2, damage);
        }

        public bool IsAlive()
        {
            return health > 0;
        }
    }
}
