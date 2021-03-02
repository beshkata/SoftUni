using System;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    class Vehicle
    {
        public Vehicle(string typeOfVehicle, 
            string modelOfVehicle, 
            string colorOfVehicle, 
            double horsepowerOfVehicle)
        {
            TypeOfVehicle = typeOfVehicle;
            ModelOfVehicle = modelOfVehicle;
            ColorOfVehicle = colorOfVehicle;
            HorsepowerOfVehicle = horsepowerOfVehicle;
        }

        public string TypeOfVehicle { get; set; }

        public string ModelOfVehicle { get; set; }

        public string ColorOfVehicle { get; set; }

        public double HorsepowerOfVehicle { get; set; }

        public void PrintVehicleInfo()
        {
            Console.WriteLine($"Type: {TypeOfVehicle}");
            Console.WriteLine($"Model: {ModelOfVehicle}");
            Console.WriteLine($"Color: {ColorOfVehicle}");
            Console.WriteLine($"Horsepower: {HorsepowerOfVehicle}");
        }

    }
    class Program
    {
        static void Main()
        {
            List<Vehicle> vehicleCatalogue = new List<Vehicle>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] vehicleInfo = input.Split();
                string typeOfVehicle = vehicleInfo[0];
                if (typeOfVehicle == "car")
                {
                    typeOfVehicle = "Car";
                }
                else
                {
                    typeOfVehicle = "Truck";
                }
                string modelOfVehicle = vehicleInfo[1];
                string colorOfVehicle = vehicleInfo[2];
                double horsepowerOfVehicle = double.Parse(vehicleInfo[3]);

                Vehicle vehicle = new Vehicle(typeOfVehicle, modelOfVehicle, colorOfVehicle, horsepowerOfVehicle);

                vehicleCatalogue.Add(vehicle);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Close the Catalogue")
            {
                for (int i = 0; i < vehicleCatalogue.Count; i++)
                {
                    if (vehicleCatalogue[i].ModelOfVehicle == input)
                    {
                        vehicleCatalogue[i].PrintVehicleInfo();
                    }
                }

                input = Console.ReadLine();
            }

            double averageCarsHorsePower = 0;
            int carsCount = 0;
            double averageTrucksHorsePower = 0;
            int trucksCount = 0;

            foreach (Vehicle vehicle1 in vehicleCatalogue)
            {
                if (vehicle1.TypeOfVehicle == "Car")
                {
                    averageCarsHorsePower += vehicle1.HorsepowerOfVehicle;
                    carsCount++;
                }
                else
                {
                    averageTrucksHorsePower += vehicle1.HorsepowerOfVehicle;
                    trucksCount++;
                }
            }

            if (carsCount == 0)
            {
                averageCarsHorsePower = 0;
            }
            else
            {
                averageCarsHorsePower /= carsCount;
            }

            if (trucksCount == 0)
            {
                averageTrucksHorsePower = 0;
            }
            else
            {
                averageTrucksHorsePower /= trucksCount;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageCarsHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTrucksHorsePower:f2}.");
        }
    }
}
