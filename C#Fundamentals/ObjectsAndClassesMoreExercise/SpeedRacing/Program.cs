using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            TraveledDistanceKm = 0.0;
        }
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double TraveledDistanceKm { get; set; }

        public void Travel(double distance)
        {
            double neededFuel = distance * FuelConsumptionPerKm;
            if (neededFuel <= FuelAmount)
            {
                TraveledDistanceKm += distance;
                FuelAmount -= neededFuel;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TraveledDistanceKm:f0}";
        }
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
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionPerKm = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKm);
                cars.Add(car);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] travelInfo = input.Split();
                string carModel = travelInfo[1];
                double distance = double.Parse(travelInfo[2]);

                foreach (Car car in cars)
                {
                    if (car.Model == carModel)
                    {
                        car.Travel(distance);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (Car car1 in cars)
            {
                Console.WriteLine(car1);
            }
        }
    }
}
