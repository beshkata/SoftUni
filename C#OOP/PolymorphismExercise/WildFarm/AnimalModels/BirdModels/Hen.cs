namespace WildFarm.AnimalModels.BirdModels
{
    public class Hen : Bird
    {
        private const double WeightPerFoodEaten = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double Weight => FoodEaten > 0 
            ? base.Weight + WeightPerFoodEaten * FoodEaten
            : base.Weight;
        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
