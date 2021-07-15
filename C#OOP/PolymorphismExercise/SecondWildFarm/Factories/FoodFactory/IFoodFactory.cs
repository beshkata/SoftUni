using SecondWildFarm.Foods;

namespace SecondWildFarm.Factories.FoodFactory
{
    public interface IFoodFactory
    {
        public Food CreateFood(string foodInfo);
    }
}
