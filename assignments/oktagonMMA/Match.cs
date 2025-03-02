using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oktagonMMA
{
    internal class Match
    {
        #region Constructor
        public Match()
        {
          
        }
        #endregion

        #region Functions

        private static Random rnd = new Random();

        //na zaklade zkusenosti vypocitame moznou odchylku od ocekavaneho vysledku
        int GetExperienceBasedRandomness(Fighter fighter)
        {
            int experienceFactor = 10 - (fighter.experience / 10); //cim vic zkusenosti ma, tim mensi rozptyl nahodne hodnoty
            return rnd.Next(-experienceFactor, experienceFactor);
        }

        public Fighter SimulateFight(Fighter fight1, Fighter fight2, Organization org)
        {
            int fighter1Score = 0;
            int fighter2Score = 0;

            Console.WriteLine($"\n {fight1.name} vs {fight2.name}");
            Console.WriteLine("Zacina zapas...");

            //sance na KO
            double koChanceFighter1 = (fight1.strength * 0.7 + fight1.speed * 0.3) / 2;
            double koChanceFighter2 = (fight2.strength * 0.7 + fight2.speed * 0.3) / 2;

            //nahodna kontrola KO
            if (rnd.NextDouble() < koChanceFighter1 / 100.0)
            {
                Console.WriteLine($" Brutalni KO! {fight1.name} vyhrava KO v 1. kole!");
                org.EarnFromMatch(fight1, fight2, fight1);
                return fight1;
            }
            if (rnd.NextDouble() < koChanceFighter2 / 100.0)
            {
                Console.WriteLine($" Sokujici KO! {fight2.name} vitezi knockoutem!");
                org.EarnFromMatch (fight1,fight2, fight1);
                return fight2;
            }

            //vypocet pomeru jednotlivych skillu
            int strikingDiff = fight1.strikingSkills - fight2.strikingSkills + GetExperienceBasedRandomness(fight1) - GetExperienceBasedRandomness(fight2);
            if (strikingDiff > 0) fighter1Score++;
            else if (strikingDiff < 0) fighter2Score++;

            int grapplingDiff = fight1.grapplingSkills - fight2.grapplingSkills + GetExperienceBasedRandomness(fight1) - GetExperienceBasedRandomness(fight2);
            if (grapplingDiff > 0) fighter1Score++;
            else if (grapplingDiff < 0) fighter2Score++;

            int speedDiff = fight1.speed - fight2.speed + GetExperienceBasedRandomness(fight1) - GetExperienceBasedRandomness(fight2);
            if (speedDiff > 0) fighter1Score++;
            else if (speedDiff < 0) fighter2Score++;

            int strengthDiff = fight1.strength - fight2.strength + GetExperienceBasedRandomness(fight1) - GetExperienceBasedRandomness(fight2);
            if (strengthDiff > 0) fighter1Score++;
            else if (strengthDiff < 0) fighter2Score++;

            //urceni viteze
            Fighter winner;
            if (fighter1Score>fighter2Score)
            {
                winner = fight1;
            }
            else
            {
                winner = fight2;
            }

            //oznameni viteze + aktualizace financi
            Console.WriteLine($"\n Vitezem se stava {winner.name} \n");
            org.EarnFromMatch(fight1, fight2, winner);
            return winner;
        }

        public void SignNewFighter(Organization org)
        {
            bool isFinished = false;
            while (isFinished == false)
            {
                Console.Write("Chcete podepsat noveho bojovnika? (ano/ne): ");
                string input = Console.ReadLine().ToLower();
                if (input == "ano")
                {
                    Console.WriteLine("Zde je seznam bojovniku, ktere jeste nemate podepsane:");
                    org.ToString();
                    Console.Write("Zadejte cislo bojovnika, ktereho byste chteli podepsat: ");
                    string inputFighter = Console.ReadLine();
                    Fighter selectedFighter = org.GetFighter(inputFighter);
                    Console.WriteLine($"Bojovnik {selectedFighter.name} podepsan!");
                    selectedFighter.isSigned = true;
                    isFinished = true;
                }
                else if (input == "ne")
                {
                    Console.WriteLine("Dobre. Pokracujeme tedy bez dalsiho bojovnika.");
                    isFinished = true;
                }
                else
                {
                    Console.WriteLine("Pri nacteni vstupu nastal problem. pis malym pismem bez diakritiky.");
                }
            }    
                    
        }
        #endregion
    }
}
