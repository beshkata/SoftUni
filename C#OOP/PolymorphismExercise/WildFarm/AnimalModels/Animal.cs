﻿namespace WildFarm.AnimalModels
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; }
        public virtual double Weight { get; protected set; }
        public int FoodEaten { get; set; }

        public abstract string AskForFood();
    }
}
