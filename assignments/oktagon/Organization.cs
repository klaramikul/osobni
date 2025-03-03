using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oktagon
{
    internal class Organization
    {
        //zakladni technika
        public string name { get; set; }
        public double budget { get; set; }

        public Organization(string name, double budget)
        {
            this.name = name;
            this.budget = budget;
        }

        Random rnd = new Random();

        //vypocet nahodnosti 
        public int GetExperienceBasedRandomness(Fighter fighter)
        {
            int experienceFactor = 10 - (fighter.experience / 10); //cim vic zkusenosti ma, tim mensi rozptyl nahodne hodnoty
            return rnd.Next(-experienceFactor, experienceFactor);
        }

        //porovnani skillu
        private int CompareSkills(int skill1, int skill2, Fighter fighter1, Fighter fighter2)
        {
            int diff = skill1 - skill2 + GetExperienceBasedRandomness(fighter1) - GetExperienceBasedRandomness(fighter2);
            return (diff > 0) ? 1 : 0; //zdroj formulace ChatGPT
        }

        //vypocet celkove ceny za zapas
        public double CostOfMatch(Fighter fighter1, Fighter fighter2)
        {
            return (fighter1.fightPrice + fighter2.fightPrice);
        }

        //vypocet celkoveho zisku za zapas a jeho pripsani
        public void EarnFromMatch(Fighter fighter1, Fighter fighter2, Fighter winner)
        {
            int baseIncome = 10000;
            int popularityBonus = (fighter1.popularity + fighter2.popularity) * 100;
            double attractivityBonus = 5000 - Math.Abs(fighter1.overallAbilities - fighter2.overallAbilities) * 50;
            double totalEarnings = baseIncome + popularityBonus + attractivityBonus;

            budget += totalEarnings;
            Console.WriteLine($"Organizace ziskala {totalEarnings:F1} CZK.");
            Console.WriteLine($"Aktualni rozpocet: {budget} CZK.");
        }

        //mechanika aktualizace oblibenosti a zkusenosti podle vysledku zapasu
        public void UpdateStatistics(Fighter winner, Fighter loser)
        {
            if (winner.experience <= 100)
            {
                winner.experience += 5;
                if (winner.popularity <= 100)
                {
                    winner.popularity += 5;
                    Console.WriteLine($"{winner.name} ziskal zkusenosti a zvysil si popularitu.");
                }
                else
                {
                    Console.WriteLine("Hrac uz dosahl maximalniho levelu popularity.");
                }
            }
            else
            {
                Console.Write("Hrac uz dosahl maximalni urovne zkusenosti.");
            }

            if (loser.popularity >= 5)
            {
                loser.popularity -= 5;
            }
            else
            {
                Console.WriteLine("Tento hrac uz nemuze byt mene oblibeny.");
            }

        }

        //zakladni mechanika zapasu
        public Fighter Fight (Fighter fighter1, Fighter fighter2)
        {
            int fighter1Score = 0;
            int fighter2Score = 0;

            if (CostOfMatch(fighter1, fighter2)<= budget)
            {
                budget -= CostOfMatch(fighter1, fighter2);
                Console.WriteLine("Celkova cena zapasu cini:" + CostOfMatch(fighter1,fighter2) + " Tato hodnota byla odectena z celkoveho rozpoctu organizace, ktery nini cini:"  + budget);
                Console.WriteLine($"\n--- ZAPAS: {fighter1.name} vs {fighter2.name} ---");
                Console.WriteLine("Zapas zacina... Stiskni ENTER pro pokracovani.");
                Console.ReadKey();


                //sance na KO
                double koChanceFighter1 = (fighter1.strength * 0.7 + fighter1.speed * 0.3) / 3;
                double koChanceFighter2 = (fighter2.strength * 0.7 + fighter2.speed * 0.3) / 3;

                //nahodna kontrola KO
                if (rnd.NextDouble() < koChanceFighter1 / 100.0)
                {
                    Console.WriteLine($"Neuveritelne! {fighter1.name} vitezi KO v 1. kole!");
                    return fighter1;
                }
                if (rnd.NextDouble() < koChanceFighter2 / 100.0)
                {
                    Console.WriteLine($" Sokujici KO! {fighter2.name} vitezi knockoutem!");
                    return fighter2;
                }

                //vypocet pomeru jednotlivych skillu
                fighter1Score += CompareSkills(fighter1.striking, fighter2.striking, fighter1, fighter2);
                fighter2Score += CompareSkills(fighter2.striking, fighter1.striking, fighter2, fighter1);

                fighter1Score += CompareSkills(fighter1.grappling, fighter2.grappling, fighter1, fighter2);
                fighter2Score += CompareSkills(fighter2.grappling, fighter1.grappling, fighter2, fighter1);

                fighter1Score += CompareSkills(fighter1.speed, fighter2.speed, fighter1, fighter2);
                fighter2Score += CompareSkills(fighter2.speed, fighter1.speed, fighter2, fighter1);

                fighter1Score += CompareSkills(fighter1.strength, fighter2.strength, fighter1, fighter2);
                fighter2Score += CompareSkills(fighter2.strength, fighter1.strength, fighter2, fighter1);

                //urceni viteze
                Fighter winner;
                Fighter loser;
                if (fighter1Score > fighter2Score)
                {
                    winner = fighter1;
                    loser = fighter2;
                }
                else
                {
                    winner = fighter2;
                    loser = fighter1;
                }

                //oznameni viteze
                Console.WriteLine("\n--- Vysledek zapasu ---");
                Console.WriteLine($"{fighter1.name}: {fighter1Score} bodu");
                Console.WriteLine($"{fighter2.name}: {fighter2Score} bodu");
                Console.WriteLine($"Vitez: {winner.name}!");

                //aktualizace financi
                EarnFromMatch(fighter1, fighter2, winner);

                //aktualizace statistik
                UpdateStatistics(winner, loser);

                Console.ReadKey();
                return winner;
            }
            else
            {
                Console.WriteLine("Nemas dostatek financi na tento zapas. Zkus vybrat jine bojovniky.");
                return null;
            }
        }

        //moznost podepsani noveho fightera
        public void SignNewFighter(List<Fighter> listUnsigned, List<Fighter> listSigned)
        {
            Console.WriteLine("Chces podepsat nejakeho noveho zapasnika? ano/ne");
            string input = Console.ReadLine().ToLower();

            if (input == "ano")
            {
                Console.WriteLine("Zde je seznam, ze ktereho muzes vybirat (cena bojovnika je rovna petinasobku jeho aktualni ceny za zapas):");
                foreach (var fighter in listUnsigned)
                {
                    Console.WriteLine($"{fighter.fighterNumber}: {fighter.name} - Cena za podpis: {fighter.fightPrice * 5} CZK");
                }

                int fighterNum;
                while (true)
                {
                    Console.Write("Zadejte cislo fightera, ktereho chcete podepsat: ");
                    if (int.TryParse(Console.ReadLine(), out fighterNum))
                        break;
                    Console.WriteLine("Neplatny vstup! Zadejte platne cislo bojovnika.");
                }

                Fighter fighterToSign = listUnsigned.Find(f => f.fighterNumber == fighterNum);

                if (fighterToSign == null)
                {
                    Console.WriteLine("Bojovnik s timto cislem neexistuje.");
                    return;
                }

                int signingPrice = fighterToSign.fightPrice * 5;

                if (signingPrice <= budget)
                {
                    budget -= signingPrice;
                    fighterToSign.isSigned = true;
                    listSigned.Add(fighterToSign);
                    listUnsigned.Remove(fighterToSign); // Odstranění z listu nepodepsaných bojovníků

                    Console.WriteLine($"{fighterToSign.name} byl uspesne podepsan do organizace!");
                    Console.WriteLine($"Novy rozpocet: {budget} CZK.");
                }
                else
                {
                    Console.WriteLine("Na tohoto bojovnika nemas dostatek financi.");
                }
            }
        }
    }
}
