using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oktagon
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Organization oktagonMMA = new Organization("oktagon MMA",20000);

            List<Fighter> fighters = new List<Fighter>
            {
                new Fighter(1, "Matej Penazz", 91, 74, 92, 86, 80, 65, 0, true,0),
                new Fighter(2, "David Kozma", 76, 90, 78, 81, 81, 80, 0, true,0),
                new Fighter(3, "Pirat Kristofic", 83, 87, 68, 90, 83, 83, 0, true,0),
                new Fighter(4, "Patrik Kincl", 88, 82, 80, 88, 88, 85, 0, true,0),
                new Fighter(5, "Andrej Kalasnik", 84, 75, 87, 77, 78, 66, 0, true,0),
            };

            List<Fighter> unsignedFighters = new List<Fighter>
            {
                new Fighter(6, "Marek Mazuch", 89, 79, 66, 91, 67, 70, 0, false,0),
                new Fighter(7, "Vlasto Cepo", 87, 72, 82, 89, 77, 60, 0, false,0),
                new Fighter(8, "Ivan Buchinger", 76, 88, 89, 71, 75, 88, 0, false,0),
                new Fighter(9, "Robert Pukac", 81, 70, 78, 86, 66, 55, 0, false,0),
                new Fighter(10, "Matus Juracek", 82, 78, 82, 84, 71, 69, 0, false,0),
            };

            foreach (Fighter fighter in unsignedFighters)
            {
                fighter.overallAbilities = fighter.CalculateOverallAbilities();
                fighter.fightPrice = fighter.CalculateFightPrice(fighter.overallAbilities, fighter.popularity, fighter.experience);
            }

            foreach (Fighter fighter in unsignedFighters)
            {
                fighter.overallAbilities = fighter.CalculateOverallAbilities();
                fighter.fightPrice = fighter.CalculateFightPrice(fighter.overallAbilities, fighter.popularity, fighter.experience);
            }
            
            while (oktagonMMA.budget>0)
            {
                Console.WriteLine("Seznam bojovniku:");
                foreach (var fighter in fighters)
                {
                    Console.WriteLine(fighter);
                }

                Console.WriteLine("Vyber prvniho zapasnika - napis jeho cislo (napr. 3 pro Pirata Kristofice):");
                int fighter1Num = int.Parse(Console.ReadLine());
                Fighter fighter1 = fighters.Find(f => f.fighterNumber == fighter1Num); //zdroj ChatGPT

                Console.Write("Vyber pro nej soupere (cislo): ");
                int fighter2Num = int.Parse(Console.ReadLine());
                Fighter fighter2 = fighters.Find(f => f.fighterNumber == fighter2Num);

                if (fighter1 == null || fighter2 == null || fighter1 == fighter2)
                {
                    Console.WriteLine("Neplatny vyber bojovniku!");
                    return;
                }

                Fighter winner = oktagonMMA.Fight(fighter1, fighter2);
                oktagonMMA.SignNewFighter(unsignedFighters);
            }

            Console.WriteLine("Vycerpal jsi budget organizace. Konec hry.");
        }
    }
}
