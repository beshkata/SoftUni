using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const int BaseCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double flourModifier;
        private double techniqueModifier;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        
        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }
                this.weight = value;
            }
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                string flourTypeAsLower = value.ToLower();
                if (flourTypeAsLower != "white" && flourTypeAsLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                string techniqueAsLower = value.ToLower();
                if(techniqueAsLower != "crispy" && techniqueAsLower != "chewy" && techniqueAsLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double CaloriePerGram
        {
            get
            {
                string flourTypeAsLower = FlourType.ToLower();
                string techniqueAsLower = BakingTechnique.ToLower();

                if (flourTypeAsLower == "white")
                {
                    flourModifier = 1.5;
                }
                else if(flourTypeAsLower == "wholegrain")
                {
                    flourModifier = 1.0;
                }

                if (techniqueAsLower == "crispy")
                {
                    techniqueModifier = 0.9;
                }
                else if (techniqueAsLower == "chewy")
                {
                    techniqueModifier = 1.1;
                }
                else if (techniqueAsLower == "homemade")
                {
                    techniqueModifier = 1.0;
                }

                return BaseCaloriesPerGram * flourModifier * techniqueModifier;
            }
        }

        public double TotalCalories()
        {
            return CaloriePerGram * this.Weight;
        }
    }
}
