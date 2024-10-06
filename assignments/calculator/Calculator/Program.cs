using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        #region Functions
        #region Input
        /// <summary>
        /// Kontroluje spravny vstup operace
        /// </summary>
        /// <returns></returns>
        static int getValidOperation()
        {
            int x;
            while (true) //pokud je zjisteno nevhodne cislo, uzivatel bude opakovane zadan o zadani jineho
            {
                if (int.TryParse(Console.ReadLine(), out x) && x >= 1 && x <= 9)
                {
                    return x;
                }
                Console.WriteLine("Neplatna operace. Zadej cislo mezi 1 a 9.");
            }
        }

        /// <summary>
        /// Kontroluje spravny int vstup
        /// </summary>
        /// <returns></returns>
        static int getValidInt()
        {
            Console.WriteLine("Zadej cele cislo.");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                invalidEntry();
            }
            return x;
        }

        /// <summary>
        /// Kontroluje spravny float vstup
        /// </summary>
        /// <returns></returns>
        static float getValidFloat ()
        {
            float x;
            Console.WriteLine("Zadej cislo.");
            while (!float.TryParse(Console.ReadLine(), out x))
            {
                invalidEntry();
            }
            return x;
        }

        /// <summary>
        /// Nevhodny vstup
        /// </summary>
        static void invalidEntry()
        {
            Console.WriteLine("Neplatny vstup. Zadej cislo.");
        }

        /// <summary>
        /// Upozorneni, ze nelze delit nulou
        /// </summary>
        static void divideZero()
        {
            Console.WriteLine("Nelze delit nulou.");
        }
        #endregion
        #region Operations
        /// <summary>
        /// Soucet dvou vstupu
        /// </summary>
        /// <param name="x">prvni scitanec</param>
        /// <param name="y">druhy scitanec</param>
        /// <returns> soucet (float) </returns>
        static float add(float x, float y)
        {
            return x + y;
        }

        /// <summary>
        /// Rozdil dvou vstupu
        /// </summary>
        /// <param name="x">mensenec</param>
        /// <param name="y">mensitel</param>
        /// <returns> rozdil (float) </returns>
        static float subtract(float x, float y)
        {
            return x - y;
        }

        /// <summary>
        /// Nasobek dvou vstupu
        /// </summary>
        /// <param name="x">prvni cinitel</param>
        /// <param name="y">druhy cinitel</param>
        /// <returns>soucin (float)</returns>
        static float multiply(float x, float y)
        {
            return x * y;
        }

        /// <summary>
        /// Podil dvou vstupu
        /// </summary>
        /// <param name="x">delenec</param>
        /// <param name="y">delitel</param>
        /// <returns>podil (float)</returns>
        static float divide(float x, float y)
        {
            return x / y;
        }

        /// <summary>
        /// Druha odmocnina vstupu
        /// </summary>
        /// <param name="x">odmocnenec</param>
        /// <returns>odmocnina (float)</returns>
        static float squareRoot(float x)
        {
            return (float)Math.Sqrt(x);
        }

        /// <summary>
        /// Druha mocnina vstupu
        /// </summary>
        /// <param name="x">mocnenec</param>
        /// <returns>mocnina (vstup)</returns>
        static float squared(float x)
        {
            return (float)Math.Sqrt(x);
        }

        /// <summary>
        /// Prevod mezi ciselnymi soustavami
        /// </summary>
        /// <param name="x">vychozi cislo</param>
        /// <param name="baseValue">zaklad soustavy</param>
        /// <returns>prevedene cislo (string)</returns>
        static string convertToBase(int x, int baseValue)
        {
            return Convert.ToString(x, baseValue);
        }
        #endregion
        #endregion 

        static void Main(string[] args)
        {
            float number1 = 0;
            float number2 = 0;
            float result = 0;
            int operation;

            Console.WriteLine("Vyber si operaci a zadej: \n 1 pro soucet \n 2 pro rozdil \n 3 pro soucin \n 4 pro podil \n 5 pro odmocninu \n 6 pro mocninu \n 7 pro prevod do binarni soustavy \n 8 pro prevod do osmickove soustavy \n 9 pro prevod do sestnactkove soustavy  ");
            
            operation = getValidOperation(); //zkontroluje, zda uzivatel zadal platnou operaci
            
            if (operation <= 6) //vylouci z operaci prevody mezi ciselnymi soustavami
            {
                number1 = getValidFloat(); //nacteni prvniho vhodneho vstupu

                if (operation <= 4) //pta se na druhy vstup pouze pokud jsou k operaci potreba dva vstupy
                {
                    number2 = getValidFloat(); //nacteni druheho vhodneho vstupu
                }
            }

            switch (operation)
            {
                case 1:
                    result = add(number1, number2); //soucet
                    Console.WriteLine("Vysledek je " +  result);
                    break;

                case 2:
                    result = subtract(number1, number2); //rozdil
                    Console.WriteLine("Vysledek je " + result);
                    break;

                case 3:
                    result = multiply(number1, number2); //nasobeni
                    Console.WriteLine("Vysledek je " + result);
                    break;

                case 4:
                    if (number2 != 0)
                    {
                        result = divide(number1, number2); //deleni
                        Console.WriteLine("Vysledek je " + result);
                    }
                    else //pri deleni nulou
                    {
                        divideZero();
                    }
                    break;

                case 5:
                    result = squareRoot(number1); //odmocneni
                    Console.WriteLine("Vysledek je " + result);
                    break;

                case 6:
                    result = squared(number1); //umocneni
                    Console.WriteLine("Vysledek je " + result);
                    break;

                case 7:
                    int toConvertBinary = getValidInt(); //kontrola vstupu (cele cislo)
                    string binaryResult = convertToBase(toConvertBinary, 2); //prevod do binarni soustavy, zdroj: chat gpt
                    Console.WriteLine("Toto cislo ma v binarni soustave hodnotu  " + binaryResult);
                    break;

                case 8:
                    int toConvertOctal = getValidInt(); //kontrola vstupu (cele cislo)
                    string octalResult = convertToBase(toConvertOctal, 8); //prevod do osmickove soustavy
                    Console.WriteLine("Toto cislo ma v osmickove soustave hodnotu " + octalResult);
                    break;

                case 9:
                    int toConvertHexadecimal = getValidInt(); //kontrola vstupu (cele cislo)
                    string hexadecimalResult = convertToBase(toConvertHexadecimal, 16); //prevod do sestnactkove soustavy
                    Console.WriteLine("Toto cislo ma v sestnactkove soustave hodnotu " + hexadecimalResult);
                    break;
            }

            
            Console.ReadKey();
        }
    }
}
