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
        public string name { get; set; }
        public double budget { get; set; }

        public Organization(string name, double budget)
        {
            this.name = name;
            this.budget = budget;
        }

        Random rnd = new Random();

        public int GetExperienceBasedRandomness(Fighter fighter)
        {
            int experienceFactor = 10 - (fighter.experience / 10); //cim vic zkusenosti ma, tim mensi rozptyl nahodne hodnoty
            return rnd.Next(-experienceFactor, experienceFactor);
        }

        public Fighter Fight (Fighter fighter1, Fighter fighter2)
        {
            int fighter1Score = 0;
            int fighter2Score = 0;

            if (CostOfMatch(fighter1, fighter2))
            {
                Console.WriteLine($"\n {fighter1.name} vs {fighter2.name}");
                Console.WriteLine("Zacina zapas...");

                //sance na KO
                double koChanceFighter1 = (fighter1.strength * 0.7 + fighter1.speed * 0.3) / 3;
                double koChanceFighter2 = (fighter2.strength * 0.7 + fighter2.speed * 0.3) / 3;

                //nahodna kontrola KO
                if (rnd.NextDouble() < koChanceFighter1 / 100.0)
                {
                    Console.WriteLine($" Brutalni KO! {fighter1.name} vyhrava KO v 1. kole!");
                    EarnFromMatch(fighter1, fighter2, fighter1);
                    return fighter1;
                }
                if (rnd.NextDouble() < koChanceFighter2 / 100.0)
                {
                    Console.WriteLine($" Sokujici KO! {fighter2.name} vitezi knockoutem!");
                    EarnFromMatch(fighter1, fighter2, fighter1);
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
                if (fighter1Score > fighter2Score)
                {
                    winner = fighter1;
                }
                else
                {
                    winner = fighter2;
                }

                //oznameni viteze + aktualizace financi
                Console.WriteLine($"{fighter1.name} skore: {fighter1Score}");
                Console.WriteLine($"{fighter2.name} skore: {fighter2Score}");
                Console.WriteLine($"\n Vitezem se stava {winner.name} \n");
                EarnFromMatch(fighter1, fighter2, winner);
                Console.ReadKey();
                return winner;
            }
            else
            {
                Console.WriteLine("Nemas dostatek financi na tento zapas. Zkus vybrat jine bojovniky.");
                return null;
            }
        }

        private int CompareSkills(int skill1, int skill2, Fighter fighter1, Fighter fighter2)
        {
            int diff = skill1 - skill2 + GetExperienceBasedRandomness(fighter1) - GetExperienceBasedRandomness(fighter2);
            return (diff > 0) ? 1 : 0;
        }
        public bool CostOfMatch(Fighter fighter1, Fighter fighter2)
        {
            if (fighter1.fightPrice + fighter2.fightPrice <= budget)
                return true;
            else return false;
        }
        public void EarnFromMatch(Fighter fighter1, Fighter fighter2, Fighter winner)
        {
            int baseIncome = 10000;
            int popularityBonus = (fighter1.popularity + fighter2.popularity) * 100;
            double attractivityBonus = 5000 - Math.Abs(fighter1.overallAbilities - fighter2.overallAbilities) * 50;
            double totalEarnings = baseIncome + popularityBonus + attractivityBonus;

            budget += totalEarnings;
            Console.WriteLine($" Organizace vydelala {totalEarnings:F1} CZK. Novy rozpocet: {budget} CZK.");
        }

        public void SignNewFighter(List<Fighter> list)
        {
            Console.WriteLine("Chces podepsat nejakeho noveho zapasnika? ano/ne");
            string input = Console.ReadLine();
            if (input == "ano")
            {
                Console.WriteLine("Zde je seznam, ze ktereho muzes vybirat (cena bojovnika je rovna petinasobku jeho aktualni ceny za zapas):");
                foreach (var fighter in list)
                {
                    Console.WriteLine(fighter);
                }
                int fighter1Num = int.Parse(Console.ReadLine());
                Fighter fighter1 = list.Find(f => f.fighterNumber == fighter1Num);
                if (fighter1.fightPrice * 5 <= budget)
                {
                    budget-=fighter1.fightPrice;
                    Console.WriteLine("Zapasnik" + fighter1.name + "byl podepsan.");
                }
                else
                {
                    Console.WriteLine("Na tohoto hrace nemas dostatek financi, zkus to v pristim kole.");
                }
            }
        }
    }
}
