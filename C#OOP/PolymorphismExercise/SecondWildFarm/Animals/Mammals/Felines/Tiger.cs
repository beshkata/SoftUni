using System.Collections.Generic;

namespace SecondWildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            FoodModifier = 1.00;
            AllowedFood = new List<string>()
            {
                "Meat"
            };

        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
