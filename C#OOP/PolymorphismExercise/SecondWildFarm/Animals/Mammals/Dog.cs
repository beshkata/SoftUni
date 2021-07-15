using System.Collections.Generic;

namespace SecondWildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            FoodModifier = 0.4;
            AllowedFood = new List<string>()
            {
                "Meat"                
            };

        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
