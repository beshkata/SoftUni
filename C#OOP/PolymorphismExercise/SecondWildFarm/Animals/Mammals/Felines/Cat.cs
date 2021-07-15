using System.Collections.Generic;

namespace SecondWildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            FoodModifier = 0.30;
            AllowedFood = new List<string>()
            {
                "Meat",
                "Vegetable"
            };
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
