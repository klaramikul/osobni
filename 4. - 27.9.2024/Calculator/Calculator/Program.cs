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
        static void Main(string[] args)
        {
            float number1 = 0;
            float number2 = 0;
            float result = 0;

            Console.WriteLine("Vyber si operaci a zadej: \n 1 pro soucet \n 2 pro rozdil \n 3 pro soucin \n 4 pro podil \n 5 pro prevod mezi ciselnymi soustavami");

            int operation = Convert.ToInt32(Console.ReadLine());

            if (operation != 5) //rozdeli mezi beznymi mat. operacemi a prevodem mezi cis. soustavami
            {
                Console.WriteLine("Zadej prvni cislo.");
                while (!float.TryParse(Console.ReadLine(), out number1)) //kontroluje vstup a opakuje program do zadani vhodneho vstupu, zdroj prikazu: Chat GPT
                {
                    Console.WriteLine("Neplatny vstup. Zadej cislo.");
                }

                Console.WriteLine("Zadej druhe cislo.");
                while (!float.TryParse(Console.ReadLine(), out number2))
                {
                    Console.WriteLine("Neplatny vstup. Zadej cislo.");
                }

                bool validOperation = false; //opakuje operace dokud neni zadan vhodny vstup operace, zdroj: Chat GPT

                while (!validOperation)
                {
                    if (operation == 1)
                    {
                        result = number1 + number2;
                        Console.WriteLine("Vysledek je " + result);
                        validOperation = true;

                    }
                    else if (operation == 2)
                    {
                        result = number1 - number2;
                        Console.WriteLine("Vysledek je " + result);
                        validOperation = true;
                    }
                    else if (operation == 3)
                    {
                        result = number1 * number2;
                        Console.WriteLine("Vysledek je " + result);
                        validOperation = true;
                    }
                    else if (operation == 4)
                    {
                        if (number2 != 0)
                        {
                            result = number1 / number2;
                            Console.WriteLine("Vysledek je " + result);
                            validOperation = true;
                        }
                        else
                        {
                            Console.WriteLine("Nelze delit nulou.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Neplatna operace");
                    }
                }

            }
            else // prevod mezi cis. soustavami
            {
                bool validOperation = false;
                while (!validOperation)
                {
                    Console.WriteLine("Zadej prvni cislo.");
                    if (float.TryParse(Console.ReadLine(), out number1) || number1 > 0 || number1 % 1 != 0)
                    {
                        validOperation = true;
                    }
                    else
                    {
                        Console.WriteLine("Zadej cele, kladne cislo");
                    }

                    Console.WriteLine(); //pro citelnost

                    Console.WriteLine("Zadej zaklad cilove soustavy (2 - 36)");
                    if (float.TryParse(Console.ReadLine(), out number2) || number2 >= 2 || number2 <= 36)
                    {
                        validOperation=true;
                    }
                    else
                    {
                        Console.WriteLine("Zadej zaklad mezi 2 a 36");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
