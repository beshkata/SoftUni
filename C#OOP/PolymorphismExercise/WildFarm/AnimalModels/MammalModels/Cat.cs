namespace WildFarm.AnimalModels.MammalModels
{
    public class Cat : Feline
    {
        private const double WeightPerFoodEaten = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double Weight => FoodEaten > 0
            ? base.Weight + WeightPerFoodEaten * FoodEaten
            : base.Weight;
        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
