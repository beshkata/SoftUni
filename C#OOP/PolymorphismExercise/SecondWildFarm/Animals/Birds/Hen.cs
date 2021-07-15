using System.Collections.Generic;

namespace SecondWildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            FoodModifier = 0.35;
            AllowedFood = new List<string>()
            {
                "Meat",
                "Vegetable",
                "Fruit",
                "Seeds"
            };

        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
