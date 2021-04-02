using System;
using System.Linq;
using System.Collections.Generic;

namespace NeedForSpeed
{
    class Car
    {
        const int fuelTankCapacity = 75;
        const int minMileage = 10000;

        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }
        public string Name { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public void Drive(int distance, int neededFuel)
        {
            if (Fuel < neededFuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }

            Mileage += distance;
            Fuel -= neededFuel;

            Console.WriteLine($"{Name} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");
        }

        public void Refuel(int fuel)
        {
            if (Fuel + fuel > fuelTankCapacity)
            {
                fuel = fuelTankCapacity - Fuel;
            }

            Fuel += fuel;
            Console.WriteLine($"{Name} refueled with {fuel} liters");
        }

        public void Revert(int kilometers)
        {
            if (Mileage - kilometers < minMileage)
            {
                Mileage = minMileage;
                return;
            }

            Mileage -= kilometers;
            Console.WriteLine($"{Name} mileage decreased by {kilometers} kilometers");
        }

        public override string ToString()
        {
            return $"{Name} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < count; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split('|');

                string name = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                Car car = new Car(name, mileage, fuel);

                cars.Add(car.Name, car);
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] tokens = line.Split(" : ");

                string command = tokens[0];
                string name = tokens[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(tokens[2]);
                    int neededFuel = int.Parse(tokens[3]);

                    if (!cars.ContainsKey(name))
                    {
                        continue;
                    }

                    cars[name].Drive(distance, neededFuel);

                    if (cars[name].Mileage >= 100000)
                    {
                        cars.Remove(name);
                        Console.WriteLine($"Time to sell the {name}!");
                    }
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(tokens[2]);

                    cars[name].Refuel(fuel);
                }

                else if (command == "Revert")
                {
                    int kilometers = int.Parse(tokens[2]);

                    cars[name].Revert(kilometers);
                }
            }

            Dictionary<string, Car> sorted = cars
                .OrderByDescending(c => c.Value.Mileage)
                .ThenBy(c => c.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var car in sorted)
            {
                Console.WriteLine(car.Value.ToString());
            }
        }
    }
}
