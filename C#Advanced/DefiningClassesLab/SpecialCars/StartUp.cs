using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tireList = new List<Tire[]>();
            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                double[] tireInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                Tire tireOne = new Tire((int)tireInfo[0], tireInfo[1]);
                Tire tireTwo = new Tire((int)tireInfo[2], tireInfo[3]);
                Tire tireThree = new Tire((int)tireInfo[4], tireInfo[5]);
                Tire tireFour = new Tire((int)tireInfo[6], tireInfo[7]);
                Tire[] tires = { tireOne, tireTwo, tireThree, tireFour };
                tireList.Add(tires);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            List<Engine> enginesList = new List<Engine>();

            while (input != "Engines done")
            {
                double[] engineInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                Engine engine = new Engine((int)engineInfo[0], engineInfo[1]);
                enginesList.Add(engine);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            List<Car> cars = new List<Car>();
            while (input != "Show special")
            {
                string[] carInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                Engine engine = enginesList[int.Parse(carInfo[5])];
                Tire[] tires = tireList[int.Parse(carInfo[6])];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

                cars.Add(car);
                input = Console.ReadLine();
            }

            cars = cars.Where(c => c.Year >= 2017 && 
            c.Engine.HorsePower > 330 && 
            c.TotalPressureInTires > 9 && 
            c.TotalPressureInTires < 10)
                .ToList();

            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Drive(20);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
