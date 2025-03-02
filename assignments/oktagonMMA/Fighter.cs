using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oktagonMMA
{
    internal class Fighter
        //dve promenne ktere se budou menit - popularita, zkusenosti + pridat startovni cisla
        //udelat jen jeden list 
    {
        #region Variables
        private string m_name;
        private int m_fighterNumber;
        private int m_strikingSkills;
        private int m_grapplingSkills;
        private int m_speed;
        private int m_strength;
        private int m_popularity;
        private int m_experience;
        private int m_fightPrice;
        private bool m_isSigned;
        private double m_overallAbilities;
        #endregion

        #region Properties
        public string name { get { return m_name; } }
        public int fighterNumber { get { return m_fighterNumber; } }
        public int strikingSkills { get { return m_strikingSkills; } }
        public int grapplingSkills { get { return m_grapplingSkills; } }
        public int speed { get { return m_speed; } }
        public int strength { get { return m_strength; } }
        public int popularity { get { return m_popularity; } }
        public int experience { get { return m_experience; } }
        public int fightPrice { get; set; }
        public bool isSigned { get; set; }
        public double overallAbilities { get; set;}
        #endregion

        #region Functions
        public override string ToString()
        {
            return
                "\n"+
                $"{m_fighterNumber}." +
                $"{m_name} \n" +
                $"Striking skill: {m_strikingSkills} \n" +
                $"Grappling skill: {m_grapplingSkills} \n" +
                $"Rychlost: {m_speed} \n" +
                $"Sila: {m_strength} \n" +
                $"Popularita: {m_popularity} \n" +
                $"Zkusenosti: {m_experience} \n" +
                $"Cena za zapas: {m_fightPrice} \n";
        }

        public Fighter(int fighterNumber, string name, int strikingSkills, int grapplingSkills, int speed, int strength, int popularity, int experience, int fightPrice, bool isSigned)
        {
            this.m_fighterNumber = fighterNumber;
            this.m_name = name;
            this.m_strikingSkills = strikingSkills;
            this.m_grapplingSkills = grapplingSkills;
            this.m_speed = speed;
            this.m_strength = strength;
            this.m_popularity = popularity;
            this.m_experience = experience;
            this.m_fightPrice = fightPrice;
            this.m_isSigned = isSigned;
            this.CalculateOverallAbilities(strikingSkills, grapplingSkills, speed, strength, popularity, experience);
        }

        public void CalculateOverallAbilities(int strikingSkills, int grapplingSkills, int speed, int strength, int popularity, int experience)
        {
            overallAbilities = 1.5 * strikingSkills + 1.2 * grapplingSkills + speed + strength + 0.8 * popularity + 1.3 * experience;
        }

        public int CalculateFightPrice(double overallAbilities)
        {
            int fightPrice = (int) overallAbilities / 5;
            return fightPrice;
        }
        #endregion
    }
}
