namespace WildFarm.AnimalModels.MammalModels
{
    public class Tiger : Feline
    {
        private const double WeightPerFoodEaten = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double Weight => FoodEaten > 0
            ? base.Weight + WeightPerFoodEaten * FoodEaten
            : base.Weight;
    
        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
