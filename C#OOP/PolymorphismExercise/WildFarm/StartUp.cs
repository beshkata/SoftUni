using System;
using System.Collections.Generic;
using WildFarm.AnimalModels;
using WildFarm.AnimalModels.BirdModels;
using WildFarm.AnimalModels.MammalModels;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();
            string animalType = "";
            while (true)
            {
                string evenLine = Console.ReadLine();

                if (evenLine == "End")
                {
                    break;
                }
                string[] animalTokens = evenLine.Split();
                animalType = animalTokens[0];
                string name = animalTokens[1];
                double weight = double.Parse(animalTokens[2]);

                if (animalType == "Owl")
                {
                    double wingSize = double.Parse(animalTokens[3]);
                    Owl owl = new Owl(name, weight, wingSize);
                    animals.Add(owl);
                }
                else if (animalType == "Hen")
                {
                    double wingSize = double.Parse(animalTokens[3]);
                    Hen hen = new Hen(name, weight, wingSize);
                    animals.Add(hen);
                }
                else if (animalType == "Cat")
                {
                    string livingRegion = animalTokens[3];
                    string breed = animalTokens[4];

                    Cat cat = new Cat(name, weight, livingRegion, breed);
                    animals.Add(cat);
                }
                else if (animalType == "Tiger")
                {
                    string livingRegion = animalTokens[3];
                    string breed = animalTokens[4];

                    Tiger tiger = new Tiger(name, weight, livingRegion, breed);
                    animals.Add(tiger);
                }
                else if (animalType == "Dog")
                {
                    string livingRegion = animalTokens[3];
                    Dog dog = new Dog(name, weight, livingRegion);
                    animals.Add(dog);
                }
                else if (animalType == "Mouse")
                {
                    string livingRegion = animalTokens[3];
                    Mouse mouse = new Mouse(name, weight, livingRegion);
                    animals.Add(mouse);
                }
                
                

                string oddLine = Console.ReadLine();

                string[] foodTokens = oddLine.Split();

                string foodType = foodTokens[0];
                int foodQuantity = int.Parse(foodTokens[1]);
                int index = animals.Count - 1;
                Console.WriteLine(animals[index].AskForFood());

                if (animalType == "Hen")
                {
                    animals[index].FoodEaten += foodQuantity;
                }
                else if (animalType == "Mouse" && (foodType == "Vegetable" || foodType == "Fruit"))
                {
                    animals[index].FoodEaten += foodQuantity;
                }
                else if (animalType == "Cat" && (foodType == "Vegetable" || foodType == "Meat"))
                {
                    animals[index].FoodEaten += foodQuantity;
                }
                else if ((animalType == "Dog" || animalType == "Tiger" || animalType == "Owl") && foodType == "Meat")
                {
                    animals[index].FoodEaten += foodQuantity;
                }
                else
                {
                    Console.WriteLine($"{animalType} does not eat {foodType}!");
                }
                
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
