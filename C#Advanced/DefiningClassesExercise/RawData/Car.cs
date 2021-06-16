using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses123
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} 
        //{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"

        public Car(string model, int engineSpeed, int enginePower,
            int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoWeight, cargoType);
            Tires = new Tire[4];
            Tires[0] = new Tire(tire1Pressure, tire1Age);
            Tires[1] = new Tire(tire2Pressure, tire2Age);
            Tires[2] = new Tire(tire3Pressure, tire3Age);
            Tires[3] = new Tire(tire4Pressure, tire4Age);
        }

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public Cargo Cargo { get => cargo; set => cargo = value; }
        public Tire[] Tires { get => tires; set => tires = value; }

        public static Car CreateCar(string input)
        {
            string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = tokens[0];
            int engineSpeed = int.Parse(tokens[1]);
            int enginePower = int.Parse(tokens[2]);
            int cargoWeight = int.Parse(tokens[3]);
            string cargoType = tokens[4];
            double tire1Pressure = double.Parse(tokens[5]);
            int tire1Age = int.Parse(tokens[6]);
            double tire2Pressure = double.Parse(tokens[7]);
            int tire2Age = int.Parse(tokens[8]);
            double tire3Pressure = double.Parse(tokens[9]);
            int tire3Age = int.Parse(tokens[10]);
            double tire4Pressure = double.Parse(tokens[10]);
            int tire4Age = int.Parse(tokens[12]);

            Car car = new Car(model, engineSpeed, enginePower, cargoWeight, 
                cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, 
                tire3Pressure, tire3Age, tire4Pressure, tire4Age);

            return car;
        }
    }
}
