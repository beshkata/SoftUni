using System.Collections.Generic;

using SecondWildFarm.Animals;
using SecondWildFarm.Exceptions;
using SecondWildFarm.Factories.AnimalFactory;
using SecondWildFarm.Factories.FoodFactory;
using SecondWildFarm.Foods;
using SecondWildFarm.IO.Readers;
using SecondWildFarm.IO.Writers;


namespace SecondWildFarm.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFoodFactory foodFactory;
        private IAnimalFactory animalFactory;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.foodFactory = new FoodFactory();
            this.animalFactory = new AnimalFactory();
        }

        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string input = reader.ReadLine();

                if (input == "End")
                {
                    break;
                }

                Animal animal = animalFactory.CreateAnimal(input);
                animals.Add(animal);
                Food food = foodFactory.CreateFood(reader.ReadLine());

                writer.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(food);
                }
                catch (InvalidFoodException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (Animal animal1 in animals)
            {
                writer.WriteLine(animal1.ToString());
            }
        }
    }
}
