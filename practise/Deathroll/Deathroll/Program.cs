using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Deathroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int goldUser = 1000;
            int goldComputer = 1000;
            Console.WriteLine("Vitej ve hre Deathroll.");
            Console.WriteLine("Tvuj aktualni pocet goldu: " + goldUser + " Muj aktualni pocet goldu: " + goldComputer);
            while (goldUser > 0 && goldComputer > 0)
            {
                Console.WriteLine("Vsad vybrany pocet svych goldu.");
                int rollUser = Convert.ToInt32(Console.ReadLine());
                if (rollUser > goldUser)
                {
                    Console.WriteLine("Nemuzes vsazet vice goldu, nez mas.");
                    break;
                }
                else if (rollUser <= 0)
                {
                    Console.WriteLine("Musis zvolit kladne cislo.");
                    break;
                }

                int firstRoll = rollUser;
                int rollComputer = firstRoll;
                while (rollUser != 1 && rollComputer != 1)
                {
                    Console.WriteLine("Tocim mezi 1 a " + rollComputer + "(zmackni enter)");
                    Console.ReadKey();
                    rollUser = rng.Next(1, rollComputer);
                    Console.WriteLine("Padlo ti " + rollUser + "(zmackni enter)");
                    if (rollUser == 1) break;
                    Console.ReadKey();
                    Console.WriteLine("Tocim mezi 1 a " + rollUser + "(zmackni enter)");
                    Console.ReadKey();
                    rollComputer = rng.Next(1, rollUser);
                    Console.WriteLine("Mne padlo " + rollComputer + "(zmackni enter)");
                    if (rollComputer == 1) break;
                    Console.ReadKey();
                }

                if (rollComputer == 1)
                {
                    Console.WriteLine("Prohral jsem.");
                    goldComputer = goldComputer - firstRoll;
                    Console.WriteLine("Tvuj aktualni pocet goldu: " + goldUser + " Muj aktualni pocet goldu: " + goldComputer);
                }
                if (rollUser == 1)
                {
                    Console.WriteLine("Prohral jsi.");
                    goldUser = goldUser - firstRoll;
                    Console.WriteLine("Tvuj aktualni pocet goldu: " + goldUser + " Muj aktualni pocet goldu: " + goldComputer);
                }
            }
            
            if (goldComputer == 0)
            {
                Console.WriteLine("Konec. Uz nemam goldy.");
            }
            else if (goldUser == 0)
            {
                Console.WriteLine("Konec. Uz nemas goldy.");
            }

            Console.ReadKey();


            /*
             * Jednoduchy program na procviceni podminek a cyklu (lze udelat i rekurzi).
             * 
             * Vytvor program, kde bude uzivatel hrat s pocitacem deathroll.
             * Pravidla deathrollu: Prvni hrac navrhne cislo (puvodne ve wowku pocet goldu, o ktere se hraci vsadi) a "rollne" navrhnute cislo, jinak receno je to stejne,
             * jako kdyby si hodil kostkou s tolika stenami, jako je navrhnute cislo. Prvnimu hraci "padne" nejake cislo a druhy hrac si "rollne" padnute cislo
             * (ktere uz je mensi nez to predesleho hrace).
             * Prohrava ten hrac, kteremu padne 1 jako prvnimu.
             * Ukazka hry: Hraci se shodnou na cisle 1000. Prvni hrac rollne 1-1000, padne mu 920. Druhy hrac rolluje 1-920, padne mu 235 atd. atd. az jednomu z hracu padne 1
             * a ten prohrava.
             * 
             * Struktura:
             * 
             * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy aktualne rollovane cislo a stav "goldu" uzivatele i pocitace (oba zacinaji treba s 1000 goldu)
             * 
             * - uzivatel zada prvotni sazku, ktera musi byt maximalne tolik, kolik ma goldu
             * 
             * Opakuj dokud nepadne jednomu z hracu 1:
             * {
             *      Pokud je sude kolo:
             *      {
             *          - uzivatel zada hodnotu, kterou rolluje
             *          - kontroluj, ze uzivatel zadal spravnou hodnotu
             *          - uloz rollnute cislo
             *          - vypis uzivateli, co rollnul
             *      }
             *      Pokud je liche kolo:
             *      {
             *          - pocitac rollne nahodne cislo mezi 1 a aktualne rollovanym cislem
             *          - vypis uzivateli, co rollnul pocitac
             *      }
             * }
             * 
             * 
             * - posledni hrajici hrac prohral, protoze mu padla 1 a sazku bere druhy hrac
             * - vypis uzivateli kdo vyhral a stav goldu uzivatele i pocitace
             * 
             * ROZSIRENI:
             * - umozni uzivateli opakovat deathroll dokud ma nejake goldy
             */
        }
    }
}
