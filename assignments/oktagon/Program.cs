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
            //uvod do hry
            Console.WriteLine("Vitej v simulaci Oktagon MMA!");
            Console.WriteLine("Jako promoter organizace se staras o jeji rozpocet a planujes zapasy.");
            Console.WriteLine("Na zacatku mas 5 zapasniku a 20 000 CZK.");
            Console.WriteLine("Kazdy zapas stoji penize, ale prinasi i odmeny podle atraktivity.");
            Console.WriteLine("Atraktivita zavisi na vyrovnanosti bojovniku a jejich popularite.");
            Console.WriteLine("Promyslene planuj zapasy a rozsiruj svuj tym!");

            //zalozeni organizace a zapsani zapasniku
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
             
            //hlavni smycka hry
            while (oktagonMMA.budget>7491) //minimalni mozna cena za zapas, dokud je budget vyssi, uzivatel muze pokracovat
            {
                //vypocet ceny a skore dovednosti
                foreach (Fighter fighter in fighters)
                {
                    fighter.overallAbilities = fighter.CalculateOverallAbilities();
                    fighter.fightPrice = fighter.CalculateFightPrice(fighter.overallAbilities, fighter.popularity, fighter.experience);
                }

                foreach (Fighter fighter in unsignedFighters)
                {
                    fighter.overallAbilities = fighter.CalculateOverallAbilities();
                    fighter.fightPrice = fighter.CalculateFightPrice(fighter.overallAbilities, fighter.popularity, fighter.experience);
                }

                //vypis dostupnych fighteru
                Console.WriteLine("\n--- Seznam dostupnych zapasniku ---");
                foreach (var fighter in fighters)
                {
                    Console.WriteLine(fighter);
                }

                //vyber hracu pro zapas
                int fighter1Num;
                while (true)
                {
                    Console.WriteLine("Vyber prvniho zapasnika - napis jeho cislo (napr. 3 pro Pirata Kristofice):");
                    if (int.TryParse(Console.ReadLine(), out fighter1Num))
                        break;
                    Console.WriteLine("Neplatny vstup! Zadejte cislo fightera.");
                }

                Fighter fighter1 = fighters.Find(f => f.fighterNumber == fighter1Num);

                int fighter2Num;
                while (true)
                {
                    Console.Write("Vyber pro nej soupere (cislo): ");
                    if (int.TryParse(Console.ReadLine(), out fighter2Num))
                        break;
                    Console.WriteLine("Neplatny vstup! Zadejte cislo fightera.");
                }

                Fighter fighter2 = fighters.Find(f => f.fighterNumber == fighter2Num);

                while (fighter1 == null || fighter2 == null || fighter1 == fighter2)
                {
                    Console.WriteLine("Neplatna volba! Ujisti se, ze vybiras dva ruzne existujici bojovniky.");

                    while (true)
                    {
                        Console.WriteLine("Vyber prvniho zapasnika - napis jeho cislo:");
                        if (int.TryParse(Console.ReadLine(), out fighter1Num))
                            break;
                        Console.WriteLine("Neplatny vstup! Zadejte cislo fightera.");
                    }
                    fighter1 = fighters.Find(f => f.fighterNumber == fighter1Num);

                    while (true)
                    {
                        Console.Write("Vyber pro nej soupere (cislo): ");
                        if (int.TryParse(Console.ReadLine(), out fighter2Num))
                            break;
                        Console.WriteLine("Neplatny vstup! Zadejte cislo fightera.");
                    }
                    fighter2 = fighters.Find(f => f.fighterNumber == fighter2Num);
                }

                //realizace samotneho zapasu
                Fighter winner = oktagonMMA.Fight(fighter1, fighter2);

                //moznost podpisu noveho fightera
                oktagonMMA.SignNewFighter(unsignedFighters,fighters);
            }

            Console.WriteLine("Rozpocet organizace byl vycerpan. Jiz nemas finance na realizaci dalsiho zapasu. Hra konci.");
            Console.ReadKey();
        }
    }
}
