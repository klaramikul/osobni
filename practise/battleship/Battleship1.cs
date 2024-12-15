using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship1
{
    internal class Program
    {
        #region Functions

        /// <summary>
        /// Naplni pole pomlckami
        /// </summary>
        /// <param name="array">pole, ktere naplni</param>
        static void FillArray(string[,] array)
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    array[i, j] = "-";
                }
            }
            for (int i = 0; i < 10; i++)
            {
                char rowChar = (char)('A' + i); //zdroj Chat GPT
                string value = rowChar.ToString();
                array[0, i + 1] = value;
            }
            for (int i = 1; i < 11; i++)
            {
                array[i, 0] = i.ToString();
            }
        }

        /// <summary>
        /// mechanika vypsani pole
        /// </summary>
        /// <param name="array"> pole k vypsani </param>
        static void DisplayArray(string[,] array)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// funkce, ktera zobrazi pole hrace i pocitace
        /// </summary>
        /// <param name="array1"> jedno pole k vypsani </param>
        /// <param name="array2"> druhe pole k vypsani </param>
        static void DisplayArrays(string[,] array1, string[,] array2)
        {
            Console.WriteLine("Tvoje pole:");
            DisplayArray(array1);
            Console.WriteLine();
            Console.WriteLine("Moje pole:");
            DisplayArray(array2);
        }

        /// <summary>
        /// kontrola spravnosti souradnic
        /// </summary>
        /// <param name="coordinates">souradnice ve formatu (int, int)</param>
        /// <returns>lze/nelze pouzit</returns>
        static bool CheckCoordinates((int, int) coordinates, string[,] array)
        {
            if (0 < coordinates.Item1 && coordinates.Item1 < 11 && 0 < coordinates.Item2 && coordinates.Item2 < 11) //jsou-li v poli
            {
                if (array[coordinates.Item1, coordinates.Item2] != "L")
                {
                    return true;
                }
                Console.WriteLine("Tam uz mas lod umistenou...");
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// kontrola, zda lod nepresahuje pole, nebo se nekryje s jinou
        /// </summary>
        /// <param name="array">v jakem poli</param>
        /// <param name="coordinates">pocatecni souradnice</param>
        /// <param name="orientation">orientace</param>
        /// <param name="dimensions">velikost lodi</param>
        /// <returns>lze/nelze umistit</returns>
        static bool CheckPlacement(string[,] array, (int, int) coordinates, int orientation, int dimensions)
        {
            if (orientation == 0)
            {
                if (coordinates.Item1 + dimensions > 11) return false; //presahuje pole
                for (int i = 0; i < dimensions; i++)
                {
                    if (array[coordinates.Item1 + i, coordinates.Item2] == "L") return false; //na jednom z poli uz je lod
                }
            }
            else
            {
                if (coordinates.Item2 + dimensions > 11) return false;
                for (int i = 0; i < dimensions; i++)
                {
                    if (array[coordinates.Item1, coordinates.Item2 + i] == "L") return false;
                }
            }
            return true;
        }

        /// <summary>
        /// prepise vstup na format, ktery lze v poli vyuzit
        /// </summary>
        /// <param name="input"> souradnice zadane hracem </param>
        /// <returns>souradnice</returns>
        /// <exception cref="FormatException">nevyhovujici poli</exception>
        static (int, int) ConvertInputToCoordinate(string input)
        {
            if (input.Length < 2 || !char.IsLetter(input[0]) || !int.TryParse(input.Substring(1), out int row)) //nevyhovujici formaty
            {
                throw new FormatException("Neplatný formát souřadnic.");
            }
            int col = char.ToUpper(input[0]) - 'A' + 1; //prepise pismeno na souradnici, s pomoci Chat GPT
            return (row, col);
        }

        /// <summary>
        /// Prepise souradnice na symbolicke pole
        /// </summary>
        /// <param name="r">radek</param>
        /// <param name="c">sloupec</param>
        /// <returns>pole</returns>
        static string ConvertCoordinatestoInput(int r, int c)
        {
            char col = (char)('A' + (c-1));
            int row = r - 1;
            return $"{col}{row}"; //s pomoci Chat GPT
        }

        /// <summary>
        /// zepta se hrace na pocatecni souradnice konkretni lodi
        /// </summary>
        /// <returns>souradnice v poli (int,int)</returns>
        static (int, int) GetCoordinates(string[,] array)
        {
            while (true)
            {
                Console.WriteLine("Napis souradnice (napr. G5):");
                Console.WriteLine();//pro prehlednost
                string input = Console.ReadLine();

                try
                {
                    (int, int) coordinates = ConvertInputToCoordinate(input); //prepise na stravitelny format

                    if (!CheckCoordinates(coordinates, array)) //zkontroluje, zda vyhovují
                    {
                        Console.WriteLine("Souradnice jsou mimo povoleny rozsah (1-10 pro radky, A-J pro sloupce).");
                        Console.WriteLine();
                        continue;
                    }

                    return coordinates;
                }
                catch (FormatException) //zdroj Chat GPT
                {
                    Console.WriteLine("Neplatny format. Zadej souradnice ve formatu pismeno a cislo (napr. C3).");
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// zepta se hrace na orientaci konkretni lodi
        /// </summary>
        /// <returns>0 pro vertikalni, 1 pro horizontalni (int)</returns>
        static int GetOrientation()
        {
            while (true)
            {
                Console.WriteLine("Chces lod umistit vertikalne (0), nebo horizontalne (1)?");
                Console.WriteLine();

                if (int.TryParse(Console.ReadLine(), out int orientation) && (orientation == 0 || orientation == 1))
                {
                    return orientation;
                }

                Console.WriteLine("Zadej 0 pro vertikalni, nebo 1 pro horizontalni umisteni.");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Umisteni konkretni lodi pocitace, nebo hrace
        /// </summary>
        /// <param name="array1">pole, do ktereho umistujeme</param>
        /// <param name="array2">viditelne pole pocitace</param>
        /// <param name="dimensions">velikost lodi</param>
        /// <param name="isRandom">random zadani orientace, pocatecniho bodu?</param>
        static bool PlaceShip(string[,] array1, string[,] array2, int dimensions, bool isRandom)
        {
            bool IsSuccess = false;

            if (!isRandom) //rozmisteni hracovych lodi, podle jeho vlastnich pozadavku
            {

                while (true)
                {
                    Console.WriteLine("Ted umistime lod velkou 1 x " + dimensions + " Kde chces, aby zacinala?");
                    Console.WriteLine();
                    (int, int) coordinates = GetCoordinates(array1); //hrac zadava pocatecni hodnoty
                    int orientation = GetOrientation(); //hrac zadava orientaci: 0 = vertikalni, 1 = horizontalni

                    if(CheckPlacement(array1,coordinates, orientation, dimensions))
                    {
                        for (int i = 0; i < dimensions; i++)
                        {
                            if (orientation == 0) //vertikalne
                            {
                                array1[coordinates.Item1 + i, coordinates.Item2] = "L";
                            }
                            else //horizontalne
                            {
                                array1[coordinates.Item1, coordinates.Item2 + i] = "L";
                            }

                        }
                        DisplayArrays(array1, array2);
                        IsSuccess = true;
                        return IsSuccess;
                    }
                    else
                    {
                        Console.WriteLine("Takhle lod umistit nemuzes. Bud presahuje pole, nebo se krizi s jinou. Zkus to znova. ");
                        Console.WriteLine();
                        return IsSuccess;
                    }

                }
                
            }
            else  //random hodnoty pro pole pocitace
            {
                Random rng = new Random();

                while (true)
                {
                    int orientation = rng.Next(0, 2);
                    (int, int) coordinates = (rng.Next(1, 11), rng.Next(1, 11));
                    if (CheckPlacement(array1, coordinates, orientation, dimensions))
                    {
                        for (int i = 0; i < dimensions;i++)
                        {
                            if (orientation == 0) //vertikalne
                                array1[coordinates.Item1 + i, coordinates.Item2] = "L";
                            else //horizontalne
                                 array1[coordinates.Item1, coordinates.Item2 + i] = "L";
                        }
                        IsSuccess = true;
                        return IsSuccess;
                    }
                }
            }
        }

        /// <summary>
        /// Umisti lode vsech rozmeru
        /// </summary>
        /// <param name="array1">pole, kam je umistovano</param>
        /// <param name="array2">pole, ktere chci zobrazit</param>
        /// <param name="isRandom">random zadani orientace, pocatecniho bodu?</param>
        static void PlaceShips(string[,] array1, string[,] array2, bool isRandom)
        {
            while (!PlaceShip(array1, array2, 2, isRandom));
            while (!PlaceShip(array1, array2, 3, isRandom));
            while (!PlaceShip(array1, array2, 3, isRandom));
            while (!PlaceShip(array1, array2, 4, isRandom));
            while (!PlaceShip(array1, array2, 5, isRandom));
        }

        /// <summary>
        /// Kontrola, zda zbyvaji jeste nejake lode
        /// </summary>
        /// <param name="array">v jakem poli hledam</param>
        /// <returns>ano/ne</returns>
        static bool AreAllSunk(string[,] array)
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (array[i, j] == "L") return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Komu byly potopeny vsechny lode
        /// </summary>
        /// <param name="array1">pole hrace</param>
        /// <param name="array2">pole pocitace</param>
        /// <returns>kdo vyhral: true = pocitac, false = hrac</returns>
        static bool WhoWon(string[,] array1, string[,] array2)
        {
            if (AreAllSunk(array1) == true) return true; //vyhral pocitac
            else if (AreAllSunk(array2) == true) return false; //vyhral hrac
            return false;
        }


        static (int,int) GetRandomCoordinates()
        {
            Random rng = new Random();
            (int, int) coordinates = (rng.Next(1, 11), rng.Next(1, 11));
            return coordinates;
        }

        /// <summary>
        /// Kontroluje, jestli ze zasazene lodi jeste neco zbyva, pripadne ji oznaci za potopenou
        /// </summary>
        /// <param name="array">pole, ve kterem hledam</param>
        /// <param name="coordinates">misto, kam bylo streleno</param>
        /// <returns>byla/nebyla potopena</returns>
        static bool IsBoatSunk (string[,] array1, string [,] array2, (int,int) coordinates)
        {
            int orientation = 3;
            
            //zjistime orientaci
            if (coordinates.Item1 + 1 < 11 && array1[coordinates.Item1 + 1, coordinates.Item2] != "-" && array1[coordinates.Item1 + 1, coordinates.Item2] != "O" || coordinates.Item1 - 1 > 0 && array1[coordinates.Item1 - 1, coordinates.Item2] != "-" && array1[coordinates.Item1 - 1, coordinates.Item2] != "O")
            {
                orientation = 0;
            }
            if (coordinates.Item2 + 1 < 11 && array1[coordinates.Item1, coordinates.Item2 + 1] != "-" && array1[coordinates.Item1, coordinates.Item2 + 1] != "O" || coordinates.Item2 - 1 > 0 && array1[coordinates.Item1, coordinates.Item2 - 1] != "-" && array1[coordinates.Item1, coordinates.Item2 - 1] != "O")
            { 
                orientation = 1; 
            }

            bool isSunk = true;

            //zjistime, zda je potopena
            if (orientation == 0)
            {
                //smerem nahoru
                int i = coordinates.Item1;
                while (i >=1 && array1[i, coordinates.Item2] == "x") i--;
                if (i >= 1 && array1[i, coordinates.Item2] == "L") isSunk = false;

                //smerem dolu
                i = coordinates.Item1;
                while (i <= 11 && array1[i, coordinates.Item2] == "x") i++;
                if (i < 11 && array1[i, coordinates.Item2] == "L") isSunk = false;
            }
            else if (orientation == 1)
            {
                //doleva
                int i = coordinates.Item2;
                while (i >= 1 && array1[coordinates.Item1, i] == "x") i--;
                if (i >= 1 && array1[coordinates.Item1, i] == "L") isSunk = false;

                //doprava
                i = coordinates.Item2;
                while (i < 11 && array1[coordinates.Item1, i] == "x") i++;
                if (i < 11 && array1[coordinates.Item1, i] == "L") isSunk = false;
            }
            
            //propiseme do pole, ze lod je potopena
            if (orientation == 0)
            {
                int i = coordinates.Item1;
                while (i >= 1 && array2[i, coordinates.Item2] == "x") i--; //najdeme horni okraj
                i++;
                while (i<11 && array2[i, coordinates.Item2] == "x") //postupujeme dolu, dokud tam je lod
                {
                    array2[i, coordinates.Item2] = "X";
                    i++;
                }

            }
            
            else if (orientation == 1)
            {
                int i = coordinates.Item2;
                while (i >= 1 && array2[coordinates.Item1, i] == "x") i--; //najdeme levy okraj
                i++;
                while (i < 11 && array2[coordinates.Item1, i] == "x") //postupujeme doprava, dokud tam je lod
                {
                    array2[coordinates.Item1, i] = "X";
                    i++;
                }
            }
            
            return isSunk; //nenachazi-li se zadne "L" vrati true, lod je potopena

        }

        static void FireShot (string[,] array1, string [,] array2, (int, int) coordinates, bool isRandom)
        {
            if (isRandom == false)
            {

                if (array1[coordinates.Item1, coordinates.Item2] == "-")
                {
                    array2[coordinates.Item1, coordinates.Item2] = "O";
                    Console.WriteLine("Smula, nic jsi netrefil. Ted ja. Az budes ready, zmackni jakoukoliv klavesu.");
                    Console.WriteLine();
                }
                else if (array1[coordinates.Item1, coordinates.Item2] == "L")
                {
                    array2[coordinates.Item1, coordinates.Item2] = "x";
                    Console.WriteLine("Trefa! Zásah do lodi.");
                    if (IsBoatSunk(array1,array2, coordinates) == true)
                    {
                        Console.WriteLine("Potopil jsi ji celou! Ted je napsana velkymi pismeny. Az budes ready na moji strelbu, zmackni jakoukoliv klavesu.");
                        Console.WriteLine();
                    }
                }
                else if (array1[coordinates.Item1, coordinates.Item2] == "X" || array1[coordinates.Item1, coordinates.Item2] == "O")
                {
                    Console.WriteLine("Sem uz jsi strilel...Tvoje smula. Ted jsem na rade ja, zmackni jakoukoliv klavesu.");
                    Console.WriteLine();
                }
                Console.WriteLine("Moje pole:");
                DisplayArray(array2);
            }
            else
            {
                Console.WriteLine("Ted strilim ja. Vybiram pole " + ConvertCoordinatestoInput(coordinates.Item1,coordinates.Item2) + ". Zmackni klavesu.");
                Console.WriteLine();
                Console.ReadKey();
                if (array1[coordinates.Item1, coordinates.Item2] == "-")
                {
                    array1[coordinates.Item1, coordinates.Item2] = "O";
                    Console.WriteLine("Smula, nic jsem netrefil. Ted ty.");
                    Console.WriteLine();
                }
                else if (array1[coordinates.Item1, coordinates.Item2] == "L")
                {
                    array1[coordinates.Item1, coordinates.Item2] = "x";
                    Console.WriteLine("Trefa! Zásah do lodi.");
                    Console.WriteLine();
                }
                Console.WriteLine("Tvoje pole:");
                DisplayArray(array2);
                IsBoatSunk(array1, array2, coordinates);
            }
            

        }
        #endregion

        static void Main(string[] args)
        {
            //vytvorim pole
            string[,] playerBoard = new string[11, 11];
            string[,] visibleBoard = new string[11, 11];
            string[,] hiddenBoard = new string[11, 11];

            //naplnim pole
            FillArray(playerBoard);
            FillArray(visibleBoard);
            FillArray(hiddenBoard);

            //vypisu pole
            DisplayArrays(playerBoard, visibleBoard);

            //hrac umisti sve lode
            PlaceShips(playerBoard, visibleBoard,false);

            //pocitac umisti sve lode
            PlaceShips (hiddenBoard, playerBoard, true);

            //hraje se dokud nekdo nema potopene vsechny lode
            while (!AreAllSunk(playerBoard) && !AreAllSunk (hiddenBoard))
            {
                //hrac strili
                Console.WriteLine("Ted strilis ty. Muzes si vybrat 1 pole, kam zamiris.");
                FireShot(hiddenBoard, visibleBoard, GetCoordinates(visibleBoard), false);

                Console.ReadKey();
                //pocitac strili
                FireShot(playerBoard, playerBoard, GetRandomCoordinates(), true);
            }

            //zkontroluje a vyhlasi, kdo vyhral
            if (WhoWon(playerBoard,hiddenBoard) == true)
            {
                Console.WriteLine("Konec hry. Vyhral jsem, potopil jsem vsechny tve lode.");
            }
            else
            {
                Console.WriteLine("Konec hry. Vyhral jsi - potopil jsi vsechny me lode.");
            }

            Console.ReadKey();
        }
    }
}
