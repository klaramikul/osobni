using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        static void Duel (Player player, Enemy enemy)
        {
            while (player.IsAlive() && enemy.IsAlive())
            {
                enemy.Hurt(player.Attack());
                if (enemy.IsAlive())
                {
                    player.Hurt(enemy.Attack());
                }
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Player player = new Player("Řehoř", 100, 10);
            int enemiesKilled = 0;
            Random rng = new Random();
            while (player.IsAlive())
            {
                Enemy enemy = new Enemy("Test", 20 + enemiesKilled * rng.Next(5, 10), 5 + enemiesKilled * rng.Next(2,5), enemiesKilled + 1);
                Duel(player, enemy);
                enemiesKilled++;
            }
            Enemy enemy1 = new Enemy("Bandit", 20, 3, 1);
            //Duel(player, enemy1);
            Enemy enemy2 = new Enemy("Ghost", 30, 7, 3);
            //Duel(player, enemy2);
            Console.ReadKey();
        }
    }
}
