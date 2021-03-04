using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }

        public int Power { get; set; }
    }

    class Cargo
    {
        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
        public int Weight { get; set; }

        public string Type { get; set; }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }
    class Program
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>(carsCount);

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                int speed = int.Parse(carInfo[1]);
                int power = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Car car = new Car(model, new Engine(speed, power), new Cargo(cargoWeight, cargoType));

                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> result = new List<Car>();
            result = cars.Where(x => x.Cargo.Type == command).ToList();

            if (command == "fragile")
            {
                result = result.Where(x => x.Cargo.Weight < 1000).ToList();
            }
            else
            {
                result = result.Where(x => x.Engine.Power > 250).ToList();
            }

            foreach (Car car1 in result)
            {
                Console.WriteLine(car1.Model);
            }
        }
    }
}
