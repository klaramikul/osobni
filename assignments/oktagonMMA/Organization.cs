using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oktagonMMA
{
    internal class Organization
    {
        #region Variables
        private string m_name;
        private double m_budget;
        private List <Fighter> m_signedFighters;
        #endregion

        #region Properties
        public string name { get { return m_name; } }
        public double budget { get { return m_budget; } }
        public List<Fighter> signedFighters { get {  return m_signedFighters; } }
        #endregion

        #region Constructor
        public Organization(string name, double budget)
        {
            m_name = name;
            m_budget = budget;
            m_signedFighters = new List<Fighter>();
        }
        #endregion

        #region Functions
        public override string ToString()
        {
            string fightersInfo = "";
            foreach (Fighter fighter in m_signedFighters)
            {
                if (fighter.isSigned == true)
                {
                    fightersInfo += fighter.ToString() + "\n";
                }
            }

            return
                $"Organization: {name} \n" +
                $"Budget: {budget} \n" +
                "\n" +
                $"Signed fighters: {fightersInfo} \n";
                
        }

        public void AddFighter(Fighter fighter)
        {
            signedFighters.Add(fighter);
        }
        public Fighter GetFighter(string input)
        {
            while (true)
            {
                int? selectedFighterNumber = isNumber(input);
                if (selectedFighterNumber == null)
                {
                    Console.WriteLine("Toto neni jeden ze zapasniku.");
                    input = Console.ReadLine();
                    continue;
                }

                foreach (Fighter fighter in m_signedFighters)
                {
                    if (fighter.fighterNumber == selectedFighterNumber)
                    {
                        return fighter;
                    }
                }

                Console.WriteLine("Zapasnika s timto cislem nemas. Zkus to znovu.");
                input = Console.ReadLine() ;
            }
        }

        public int? isNumber (string input)
        {
            int fighterNumber;
            if (int.TryParse(input, out fighterNumber))
            {
                return fighterNumber;
            }
            else return null;
        }

        public bool PayForMatch(Fighter fighter1, Fighter fighter2)
        {
            int cost = fighter1.fightPrice + fighter2.fightPrice + 5000; //vypocet ceny zapasu
            if (m_budget >= cost)
            {
                m_budget-=cost;
                return true; //jsou penize na zapas
            }
            else
            {
                Console.WriteLine("Nedostatek financi pro usporadani zapasu. Zkus vybrat jine zapasniky.");
                return false; //neni dostatek penez
            }
        }

        public void EarnFromMatch (Fighter fighter1, Fighter fighter2, Fighter winner)
        {
            int baseIncome = 10000;
            int popularityBonus = (fighter1.popularity + fighter2.popularity) * 100;
            double attractivityBonus = 5000 - Math.Abs(fighter1.overallAbilities - fighter2.overallAbilities) * 50;

            double totalEarnings = baseIncome + popularityBonus + attractivityBonus;
            m_budget += totalEarnings;
            Console.WriteLine("Prijem z tohoto zapasu cini:" + totalEarnings + "CZK");
        }
        #endregion
    }
}
