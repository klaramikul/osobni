using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oktagon
{
    internal class Fighter
    {
        //zakladni technicke veci
        public int fighterNumber { get; set; }
        public string name { get; set; }
        public int striking { get; set; }
        public int grappling { get; set; }
        public int speed { get; set; }
        public int strength { get; set; }
        public int popularity { get; set; }
        public int experience { get; set; }
        public int fightPrice { get; set; } 
        public bool isSigned { get; set; }
        public double overallAbilities { get; set; }

        public Fighter(int fighterNumber, string name, int striking, int grappling, int speed, int strength, int popularity, int experience, int fightPrice, bool isSigned, double overallAbilities)
        {
            this.fighterNumber = fighterNumber;
            this.name = name;
            this.striking = striking;
            this.grappling = grappling;
            this.speed = speed;
            this.strength = strength;
            this.popularity = popularity;
            this.experience = experience;
            this.fightPrice = fightPrice;
            this.isSigned = isSigned;
            this.overallAbilities = overallAbilities;
        }

        //vypocet celkoveho skore dovednosti
        public double CalculateOverallAbilities()
        {
            return overallAbilities = 1.5 * striking + 1.2 * grappling + speed + strength + 0.8 * popularity + 1.3 * experience;
        }

        //vypocet ceny za zapas 1 bojovnika
        public int CalculateFightPrice(double overallAbilities, int popularity, int experience)
        {
            double basePrice = overallAbilities * 10;  // zaklad ceny
            double popularityBonus = popularity * 0.2;  // bonus za popularitu
            double experienceBonus = experience * 0.1;  // bonus za zkusenosti

            int totalPrice = (int)(basePrice + popularityBonus + experienceBonus);
            return totalPrice;
        }

        //vypsani informaci o fighterovi
        public override string ToString()
        {
            return
                $"{fighterNumber}: {name}\n" +
                $"Boj v postoji: {striking}\n" +
                $"Boj na zemi: {grappling}\n" +
                $"Rychlost: {speed}\n" +
                $"Síla: {strength}\n" +
                $"Popularita: {popularity}\n" +
                $"Zkusenosti: {experience}\n" +
                $"Cena za zapas: {fightPrice}\n";
        }
    }
}
