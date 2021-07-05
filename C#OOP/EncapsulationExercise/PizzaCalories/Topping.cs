using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;
        private const int BaseCaloriesPerGram = 2;

        private string name;
        private double modifier;
        private int weight;

        public Topping(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                string nameAsLower = value.ToLower();
                if (nameAsLower != "meat" && 
                    nameAsLower != "veggies" &&
                    nameAsLower != "cheese" && 
                    nameAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{Name} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                string nameAsLower = Name.ToLower();
                if (nameAsLower == "meat")
                {
                    modifier = 1.2;
                }
                else if (nameAsLower == "veggies")
                {
                    modifier = 0.8;
                }
                else if (nameAsLower == "cheese")
                {
                    modifier = 1.1;
                }
                else if (nameAsLower == "sauce")
                {
                    modifier = 0.9;
                }

                return BaseCaloriesPerGram * modifier;
            }
        }

        public double TotalCalories()
        {
            return this.CaloriesPerGram * this.Weight;
        }
    }
}
