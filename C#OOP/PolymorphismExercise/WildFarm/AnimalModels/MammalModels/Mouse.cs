namespace WildFarm.AnimalModels.MammalModels
{
    public class Mouse : Mammal
    {
        private const double WeightPerFoodEaten = 0.1;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double Weight => FoodEaten > 0
            ? base.Weight + WeightPerFoodEaten * FoodEaten
            : base.Weight + WeightPerFoodEaten;
        public override string AskForFood()
        {
            return "Squeak";
        }
    }
}
