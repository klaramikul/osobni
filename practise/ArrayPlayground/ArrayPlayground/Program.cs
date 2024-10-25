using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            int[] myArray = {5, 8, 13, 567, 12};


            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.
            Console.WriteLine("for cyklus");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }

            Console.WriteLine("foreach cyklus"); //tento cyklus nezaznamenava indexy --> nevi, kolikate je cislo, jen vypise jeho hodnotu
            foreach (int number in myArray)
            {
                Console.WriteLine(number);
            }

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
               sum += myArray[i];
            }
            Console.WriteLine("Suma cisel pole je " + sum);
            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            double average = (double)sum/myArray.Length; //presne deleni (double), pri deleni s int celociselna zaokrouhlena hodnota
            Console.WriteLine("Prumer je " + average);

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                if (myArray[i] > max)
                {
                    max = myArray[i];
                }
            }
            Console.WriteLine("Maximum je " + max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = int.MaxValue;
            foreach (int number in myArray)
            {
                if (number < min)
                {
                    min = number;
                }
            }
            Console.WriteLine("Minimum je " + min);

            int minimum = myArray.Min(); 

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            int index;
            Console.WriteLine("Zadej cislo, jehoz index chces vedet.");
            int numberToFind = int.Parse(Console.ReadLine());
            bool foundNumber = false;
            for (int i = 0; i < myArray.Length; i++)
            {
                if (numberToFind == myArray[i])
                {
                    Console.WriteLine("Index cisla je " + i);
                    foundNumber = true;
                    break;
                }
            }
            if (!foundNumber)
            {
                Console.WriteLine("Zadane cislo v poli neni.");
            }
            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.
            Random rng = new Random();
            myArray = new int[100]; //pro prepsani je klicove slovo new
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rng.Next(0,9);
                Console.WriteLine(myArray[i]);
            }

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int number in myArray)
            {
                counts[number]++;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine("Cetnost cislice " + i + "je " + counts);
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] myArray2 = new int[100];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray2[i] = myArray[myArray.Length - 1 - i]; //v zavorce zajistim, aby cislo bylo od konce tj. poradi (-1 protoze jde od 0) a odectu cislo, na kterem aktualne jsem
            }

            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne

            Console.ReadKey();
        }
    }
}
