using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Player
    {
        public string name;
        public int health;
        int damage;
        Random rng;

        public Player (string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            rng = new Random();
        }

        public void SetDamage (int value)
        {
            damage = value;
            if (damage <= 0)
            {
                damage = 1;
            }
        }

        public int GetDamage ()
        {
            return damage;
        }

        public void Hurt (int incomingDamage)
        {
            health = incomingDamage;
            Console.WriteLine("Player " + name + " got hurt for " + incomingDamage + " points");
            Console.WriteLine("Player health:" + health);
            if (health <= 0)
            {
                Console.WriteLine("Player " + name + "is dead.");
            }
        }

        public int Attack ()
        {
            return rng.Next(damage/2, damage + damage /2 + 1);
        }
        public bool IsAlive()
        {
            if ( health > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }
        
    }
}
