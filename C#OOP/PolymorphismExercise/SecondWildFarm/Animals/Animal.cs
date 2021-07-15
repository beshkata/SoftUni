using System.Collections.Generic;

using SecondWildFarm.Exceptions;
using SecondWildFarm.Foods;


namespace SecondWildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        protected double FoodModifier { get; set;  }

        protected List<string> AllowedFood { get; set; }
        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            string foodType = food.GetType().Name;
            if (!AllowedFood.Contains(foodType))
            {
                throw new InvalidFoodException($"{this.GetType().Name} does not eat {foodType}!");
            }

            FoodEaten += food.Quantity;
            Weight += FoodModifier * food.Quantity;
        }
    }
}
