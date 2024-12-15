using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Program
    {
        #region Functions
        #region Technical
        static string[,] FillArray(string[,] array)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    char rowChar = (char)('A' + i);
                    string value = rowChar.ToString() + (j + 1);
                    array[i, j] = value;
                }
            }
            return array;
        }
        static void WriteArray(string[,] array)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void InvalidEntry()
        {
            Console.WriteLine("Neplatny vstup.");
        }
        static void CannotPlaceShip()
        {
            Console.WriteLine("Lod se krizi s jinou, nebo presahuje pole.");
        }
        static void DisplayCurrentBoards(string[,] array1, string[,] array2)
        {
            Console.WriteLine("Tvoje pole: ");
            WriteArray(array1);
            Console.WriteLine();
            Console.WriteLine("Moje pole: ");
            WriteArray(array2);
        }
        static void DisplayPlayersBoards(string[,] array)
        {
            Console.WriteLine("Tvoje pole: ");
            WriteArray(array);
        }
        static (int, int)? GetCoordinates(string[,] array, string value) //nullable verze vystupu zdroj: Chat GPT
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (array[i, j] == value)
                    {
                        return (i, j);
                    }
                }
            }
            return null; //pokud se zadana hodnota v poli nenachazi
        }
        #endregion
        #region InputShips
        static (int, int)? StartingCoordinate(string[,] array)
        {
            Console.WriteLine("Zadej pocatecni pole (napr. G5):");
            string input = Console.ReadLine();
            var coordinates = GetCoordinates(array, input);
            if (coordinates != null)
            {
                (int row, int col) = coordinates.Value; //zdroj Chat GPT
                return coordinates;
            }
            else
            {
                InvalidEntry();
                return StartingCoordinate(array);
            }

        }
        static bool CanPlaceShip (string[,] array, int dimensions, int orientation, int row, int col)
        {
            if (orientation == 1)
            {
                if (col + dimensions > array.GetLength(1))
                    return false;
                for (int i = 0; i <dimensions; i++)
                {
                    if (array[row, col + i] == "L")
                    return false;
                }
            }
            else if (orientation == 0)
            {
                if (row + dimensions > array.GetLength(0))
                    return false;
                for (int i = 0; i < dimensions; i++)
                {
                    if (array[row + i, col] == "L")
                    return false;
                }
            }
            return true;

        }
        static void ComputerInputShip(string[,] array, int dimensions)
        {
            Random rng = new Random();
            int attempts = 0;
            int maxAttempts = 100;
            while (true)
            {
                //generovani nahodnych cisel
                int rowRandom = rng.Next(0, 10);
                int colRandom = rng.Next(0, 10);
                int orientation = rng.Next(0, 2);

                //kontrola zda je mozne lod umistit
                 

                //umisteni
            }

        }
        static void InputShip(string[,] array,int dimensions)
        {
            bool placingShip = false;
            
            while (!placingShip)
            {
                var coordinates = StartingCoordinate(array);
                if (coordinates != null)
                {
                    (int row, int col) = coordinates.Value;
                    Console.WriteLine("Vyber si orientaci lodi. Napis 1 pro horizontalni a 0 pro vertikalni.");
                    int orientation = Convert.ToInt32(Console.ReadLine());

                    if (orientation == 0)
                    {
                        for (int i = 0; i < dimensions; i++)
                        {
                            if (CanPlaceShip(array, dimensions, orientation, row, col))
                            {
                                array[row, col + i] = "L";
                                placingShip = true;
                            }
                            else
                            {
                                CannotPlaceShip();

                            }
                        }
                    }
                    else if (orientation == 1)
                    {
                        for (int i = 0; i < dimensions; i++)
                        {
                            if (CanPlaceShip(array, dimensions, orientation, row, col))
                            {
                                array[row + i, col] = "L";
                                placingShip = true;
                            }
                            else
                            {
                                CannotPlaceShip();
                            }
                        }
                    }
                    else
                    {
                        InvalidEntry();
                    }
                }
            }
        }
            
        static void InputShip1(string[,] array)
        {
            Console.WriteLine("Nyni umistime torpedoborec (1x2 policka).");
            InputShip(array, 2);
            DisplayPlayersBoards(array);
        }
        static void InputShip2(string[,] array)
        {
            Console.WriteLine("Nyni umistime kriznik (1x3 policka).");
            InputShip(array, 3);
            DisplayPlayersBoards(array);
        }
        static void InputShip3(string[,] array)
        {
            Console.WriteLine("Nyni umistime ponorku (1x3 policka).");
            InputShip(array, 3);
            DisplayPlayersBoards(array);
        }
        static void InputShip4(string[,] array)
        {
            Console.WriteLine("Nyni umistime bitevni lod (1x4 policka).");
            InputShip(array, 4);
            DisplayPlayersBoards(array);
        }
        static void InputShip5(string[,] array)
        {
            Console.WriteLine("Nyni umistime letadlovou lod (1x5 policek).");
            InputShip(array, 5);
            DisplayPlayersBoards(array);
        }
        static void InputAllShips(string[,] array)
        {
            InputShip1(array);
            InputShip2(array);
            InputShip3(array);
            InputShip4(array);
            InputShip5(array);
            Console.WriteLine("Vsechny lode jsou umistene. Muzeme zacit hrat.");
        }
        #endregion
        #endregion
        static void Main(string[] args)
        {
            //definuji pole
            string[,] playerBoard = new string[10,10];
            string[,] visibleBoard= new string[10,10];
            string[,] hiddenBoard = new string[10,10];

            //naplním je hodnotami
            playerBoard = FillArray(playerBoard);
            visibleBoard = FillArray(visibleBoard);
            hiddenBoard = FillArray(hiddenBoard);

            //vypisu aktualni pole
            DisplayCurrentBoards(playerBoard, visibleBoard);

            //nahodne umisteni lodi pocitace


            //zadani lodi hrace
            InputAllShips(playerBoard);

            Console.ReadKey();
        }

    }
}
