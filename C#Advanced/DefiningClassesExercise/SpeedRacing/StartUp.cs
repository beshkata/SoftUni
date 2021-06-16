using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Car> cars = new Dictionary<string, Car>(n);

            
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Car car = Car.CreateCar(input);
                cars.Add(car.Model, car);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[1];
                int distance = int.Parse(tokens[2]);

                cars[model].Moving(distance);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Value);
            }
        }
    }
}
