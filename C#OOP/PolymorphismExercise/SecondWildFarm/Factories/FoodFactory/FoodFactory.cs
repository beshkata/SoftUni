using SecondWildFarm.Foods;

namespace SecondWildFarm.Factories.FoodFactory
{
    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string foodInfo)
        {
            Food food = null;
            string[] tokens = foodInfo.Split();
            string foodType = tokens[0];
            int quantity = int.Parse(tokens[1]);

            if (foodType == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (foodType == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (foodType == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }
            else if (foodType == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }

            return food;
        }
    }
}
