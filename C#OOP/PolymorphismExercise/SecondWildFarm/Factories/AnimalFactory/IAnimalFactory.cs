using SecondWildFarm.Animals;

namespace SecondWildFarm.Factories.AnimalFactory
{
    public interface IAnimalFactory
    {
        public Animal CreateAnimal(string animalInfo);
    }
}
