using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;
        private const int MaxNumberOfToppings = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || 
                    value.Length < MinNameLength || 
                    value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }
        public double TotalCalories
        {
            get
            {
                double totalCalories = dough.TotalCalories();

                foreach (var topping in toppings)
                {
                    totalCalories += topping.TotalCalories();
                }
                return totalCalories;
            }
        }

        public int NumberOfToppings
        {
            get
            {
                return toppings.Count;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count < MaxNumberOfToppings)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxNumberOfToppings}].");
            }
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}
