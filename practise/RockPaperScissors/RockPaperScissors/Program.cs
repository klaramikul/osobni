using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            int myPoints = 0;
            Console.WriteLine("Vitej ve hre kamen, nuzky, papir!");
            Console.WriteLine("Pro kamen napis 0, pro papir 1 a pro nuzky 2. Hrajeme na tri vitezne bod.");
            Console.WriteLine("Tvuj aktualni pocet bodu:" + points);
            string input = Console.ReadLine();
            int choice = int.Parse(input);
            Random rng = new Random();
            int result; //0 -  jeho prohra, 1 - remíza, 2 - jeho výhra
            while ((points < 3) && (myPoints < 3))
            {
                    int myChoice = rng.Next(2);
                    if (myChoice == 0)
                    {
                        Console.WriteLine("Ja volim kamen.");
                        if (choice == 1)
                        {
                            result = 2;
                        }
                        else if (choice == 2)
                        {
                            result = 0;
                        }
                        else
                        {
                            result = 1;
                        }
                    }

                    else if (myChoice == 1)
                    {
                        Console.WriteLine("Ja volim papir.");
                        if (choice == 1)
                        {
                            result = 1;
                        }
                        else if (choice == 2)
                        {
                            result = 2;
                        }
                        else
                        {
                            result = 0;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Ja volim nuzky.");
                        if (choice == 1)
                        {
                            result = 0;
                        }
                        else if (choice == 2)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = 2;
                        }
                    }
                    switch (result)
                    {
                        case 0:
                            myPoints++;
                            Console.WriteLine("Prohral jsi.");
                            Console.WriteLine("Ty:" + points + "Ja:" + myPoints);
                            break;

                        case 1:
                            Console.WriteLine("Remiza.");
                            Console.WriteLine("Ty: " + points + "Ja: " + myPoints);
                            break;

                        case 2:
                            points++;
                            Console.WriteLine("Vyhral jsi.");
                            Console.WriteLine("Ty: " + points + "Ja: " + myPoints);
                            break;
                    }
                
            }
            Console.WriteLine("Konec hry.");
            Console.WriteLine("Ty: " + points + "Ja: " + myPoints);
            /*
             * Jednoduchy program na procviceni podminek a cyklu.
             * 
             * prijmu jejich rozhodnuti (string)
             * priradim rozhodnuti cislo (ToInt32)
             * vygeneruji vlastni rozhodnuti (int)
             * porovnam nase rozhodnuti 
             * moje - jeho 
             * 
             * Vytvor program, kde bude uzivatel hrat s pocitacem kamen-nuzky-papir.
             * 
             * Struktura:
             * 
             * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy skore obou, pripadne cokoliv dalsiho budes potrebovat
             *
             * Opakuj tolikrat, kolik kol chces hrat, nebo treba do doby, nez bude mit jeden z hracu pocet bodu nutnych k vyhre:
             * {
             *      Dokud uzivatel nezada vstup spravne:
             *      {
             *          - nacitej vstup od uzivatele
             *      }
             *      
             *      - vygeneruj s pomoci rng.Next() nahodny vstup pocitace
             *      
             *      Pokud vyhral uzivatel:
             *      {
             *          - informuj uzivatele, ze vyhral kolo
             *          - zvys skore uzivateli o 1
             *      }
             *      Pokud vyhral pocitac:
             *      {
             *          - informuj uzivatele, ze prohral kolo
             *          - zvys skore pocitaci o 1
             *      }
             *      Pokud byla remiza:
             *      {
             *          - informuj uzivatele, ze doslo k remize
             *      }
             * }
             * 
             * - informuj uzivatele, jake mel skore on/a a pocitac a kdo vyhral.
             */

             //instance tridy Random pro generovani nahodnych cisel



            Console.ReadKey(); //Aby se nam to hnedka neukoncilo
        }
    }
}
