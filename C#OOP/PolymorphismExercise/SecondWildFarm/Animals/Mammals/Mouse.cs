using System.Collections.Generic;

namespace SecondWildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            FoodModifier = 0.1;
            AllowedFood = new List<string>()
            {
                "Vegetable",
                "Fruit"
            };

        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
