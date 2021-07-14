namespace WildFarm.AnimalModels.BirdModels
{
    public class Owl : Bird
    {
        private const double WeightPerFoodEaten = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double Weight => FoodEaten > 0
            ? base.Weight + WeightPerFoodEaten * FoodEaten
            : base.Weight;
        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
