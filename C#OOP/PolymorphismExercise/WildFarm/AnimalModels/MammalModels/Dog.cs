namespace WildFarm.AnimalModels.MammalModels
{
    public class Dog : Mammal
    {
        private const double WeightPerFoodEaten = 0.4;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double Weight => FoodEaten > 0
            ? base.Weight + WeightPerFoodEaten * FoodEaten
            : base.Weight;
        public override string AskForFood()
        {
            return "Woof!";
        }
    }
}
