using SecondWildFarm.Animals;
using SecondWildFarm.Animals.Birds;
using SecondWildFarm.Animals.Mammals;
using SecondWildFarm.Animals.Mammals.Felines;

namespace SecondWildFarm.Factories.AnimalFactory
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(string animalInfo)
        {
            Animal animal = null;

            string[] tokens = animalInfo.Split();
            string animalType = tokens[0];
            string name = tokens[1];
            double weight = double.Parse(tokens[2]);

            if (animalType == nameof(Hen))
            {
                double wingSize = double.Parse(tokens[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (animalType == nameof(Owl))
            {
                double wingSize = double.Parse(tokens[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == nameof(Dog))
            {
                string livingRegion = tokens[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (animalType == nameof(Mouse))
            {
                string livingRegion = tokens[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (animalType == nameof(Cat))
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == nameof(Tiger))
            {
                string livingRegion = tokens[3];
                string breed = tokens[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            return animal;
        }
    }
}
