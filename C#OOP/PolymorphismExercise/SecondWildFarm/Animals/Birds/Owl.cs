using System.Collections.Generic;

namespace SecondWildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            FoodModifier = 0.25;
            AllowedFood = new List<string>()
            {
                "Meat"
            };
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
