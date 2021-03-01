using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    public class Vehicle
    {
        public string Brand { get; set; }

        public string Model { get; set; }

    }
    class Truck : Vehicle
    {
        public Truck(string brand, string model, double weight )
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public double Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    class Car : Vehicle
    {
        public Car(string brand, string model, double horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }

    class Catalog
    {
        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; }

        public List<Car> Cars { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Catalog catalog = new Catalog();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] vehicleInfo = input.Split('/');
                string typeOfVehicle = vehicleInfo[0];
                string brand = vehicleInfo[1];
                string model = vehicleInfo[2];

                if (typeOfVehicle == "Car")
                {
                    double horsePower = double.Parse(vehicleInfo[3]);
                    Car car = new Car(brand, model, horsePower);
                    catalog.Cars.Add(car);
                }
                else
                {
                    double weight = double.Parse(vehicleInfo[3]);
                    Truck truck = new Truck(brand, model, weight);
                    catalog.Trucks.Add(truck);
                }

                input = Console.ReadLine();
            }

            catalog.Cars = catalog.Cars.OrderBy(b => b.Brand).ToList();
            catalog.Trucks = catalog.Trucks.OrderBy(b => b.Brand).ToList();

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in catalog.Cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in catalog.Trucks)
                {
                    Console.WriteLine(truck.ToString());
                }
            }
        }
    }
}
