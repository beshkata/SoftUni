using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses111//!!!!!!!!!!!!!!!!
{
    //string Model
    //double FuelAmount
    //double FuelConsumptionPerKilometer
    //double TravelledDistance
    //methods for moving 

    //"{model} {fuelAmount} {fuelConsumptionFor1km}"
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model { get => model; set => model = value; }

        public double FuelAmount { get => fuelAmount; set => fuelAmount = value; }

        public double FuelConsumptionPerKilometer { get => fuelConsumptionPerKilometer; set => fuelConsumptionPerKilometer = value; }

        public double TravelledDistance { get => travelledDistance; set => travelledDistance = value; }

        public void Moving(int distance)
        {
            if (distance * FuelConsumptionPerKilometer > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                TravelledDistance += distance;
                FuelAmount -= distance * FuelConsumptionPerKilometer;
            }
        }

        public static Car CreateCar(string input)
        {
            //"{model} {fuelAmount} {fuelConsumptionFor1km}"
            string[] carArgs = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = carArgs[0];
            double fuelAmount = double.Parse(carArgs[1]);
            double fuelConsumptionPerKilometer = double.Parse(carArgs[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

            return car;
        }

        public override string ToString()
        {
            //"{model} {fuelAmount} {distanceTraveled}"
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}
