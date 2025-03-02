using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oktagonMMA
{
    internal class Program
    {

        static void Main()
        {
            //uvod do hry
            Console.WriteLine
                ("Vitej v simulaci OktagonMMA. " +
                "\nStavas se promoterem teto organizace. " +
                "\nTvym ukolem je zajistit, aby mela k dispozici co nejvetsi rozpocet a predevsim, aby mela dobrou povest." +
                "\nNa zacatku mas k dispozici 5 zapasniku, mezi kterymi muzes simulovat zapasy a 20 000 CZK v rozpoctu" +
                "\nKazdy zapas ma svou cenu, musis tedy dobre rozmyslet, zda se ti vyplati jej poradat - za kazdy totiz dostavas odmenu v zavislosti na jeho uspesnosti u divaku. " +
                "\nAtraktivnost zapasu zalezi na vyrovnanosti protivniku, ale i jejich popularite.");
            
            //vytvoreni organizace a zapsani jejich zapasniku
            Organization oktagon = new Organization("Oktagon MMA", 50000);

            Fighter matejPenaz = new Fighter(1, "Matej Penazz", 91, 74, 92, 86, 80, 65,0, true);
            matejPenaz.fightPrice = matejPenaz.CalculateFightPrice(matejPenaz.overallAbilities);
            Fighter davidKozma = new Fighter(2, "David Kozma", 76, 90, 78, 81, 81, 80, 0, true);
            davidKozma.fightPrice = davidKozma.CalculateFightPrice(davidKozma.overallAbilities);
            Fighter piratKristofic = new Fighter(3, "Pirat Kristofic", 83, 87, 68, 90, 83, 83, 0, true);
            piratKristofic.fightPrice = piratKristofic.CalculateFightPrice(piratKristofic.overallAbilities);
            Fighter patrikKincl = new Fighter(4, "Patrik Kincl", 88, 82, 80, 88, 88, 85, 0, true);
            patrikKincl.fightPrice = patrikKincl.CalculateFightPrice(patrikKincl.overallAbilities);
            Fighter andrejKalasnik = new Fighter(5, "Andrej Kalasnik", 84, 75, 87, 77, 78, 66, 0, true);
            andrejKalasnik.fightPrice = andrejKalasnik.CalculateFightPrice(andrejKalasnik.overallAbilities);
            Fighter marekMazuch = new Fighter(6, "Marek Mazuch", 89, 79, 66, 91, 67, 70, 0, false);
            marekMazuch.fightPrice = marekMazuch.CalculateFightPrice(marekMazuch.overallAbilities);
            Fighter vlastoCepo = new Fighter(7, "Vlasto Cepo", 87, 72, 82, 89, 77, 60, 0, false);
            vlastoCepo.fightPrice = vlastoCepo.CalculateFightPrice(vlastoCepo.overallAbilities);
            Fighter ivanBuchinger = new Fighter(8, "Ivan Buchinger", 76, 88, 89, 71, 75, 88, 0, false);
            ivanBuchinger.fightPrice = ivanBuchinger.CalculateFightPrice(ivanBuchinger.overallAbilities);
            Fighter robertPukac = new Fighter(9, "Robert Pukac", 81, 70, 78, 86, 66, 55, 0, false);
            robertPukac.fightPrice = robertPukac.CalculateFightPrice(robertPukac.overallAbilities);
            Fighter matusJuracek = new Fighter(10, "Matus Juracek", 82, 78, 82, 84, 71, 69, 0, false);
            matusJuracek.fightPrice = matusJuracek.CalculateFightPrice(matusJuracek.overallAbilities);

            oktagon.AddFighter(matejPenaz);
            oktagon.AddFighter(davidKozma);
            oktagon.AddFighter(piratKristofic);
            oktagon.AddFighter(patrikKincl);
            oktagon.AddFighter(andrejKalasnik);
            oktagon.AddFighter(marekMazuch);
            oktagon.AddFighter(vlastoCepo);
            oktagon.AddFighter(ivanBuchinger);
            oktagon.AddFighter(robertPukac);
            oktagon.AddFighter(matusJuracek);

            //vypsani do konzole
            Console.WriteLine("\n" + oktagon.ToString());

            //iniciace zapasu
            while (oktagon.budget > 2000)
            {
                Match match1 = new Match();
                Fighter fighter1 = null;
                Fighter fighter2 = null;

                //vyber zapasniku uzivatelem
                string input;
                do
                {
                    Console.WriteLine("Vyber prvniho zapasnika - napis jeho cislo (napr. 3 pro Pirata Kristofice):");
                    input = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(input));

                while (fighter1 == null)
                {
                    fighter1 = oktagon.GetFighter(input);
                }

                do
                {
                    Console.WriteLine("Nyni mu vyber soupere - napis jeho cislo:");
                    input = Console.ReadLine();
                    fighter2 = oktagon.GetFighter(input);

                    if (fighter2 == fighter1)
                    {
                        Console.WriteLine("Nemuzes vybrat stejného zapasníka dvakrát! Zkus to znovu.");
                        fighter2 = null;
                    }
                } while (fighter2 == null);

                Fighter winner = match1.SimulateFight(fighter1, fighter2, oktagon);
                match1.SignNewFighter(oktagon);
                
            }
            Console.WriteLine("\nOrganizace vycerpala svuj rozpocet. Konec simulace.");

            Console.ReadKey();
        }
    }
}
