using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engArgs[0];
                int power = int.Parse(engArgs[1]);
                int displacement = -1;
                string efficiency = "n/a";
                if (engArgs.Length == 3)
                {
                    if (!int.TryParse(engArgs[2], out displacement))
                    {
                        displacement = -1;
                        efficiency = engArgs[2];
                    }
                    
                }
                
                if (engArgs.Length == 4)
                {
                    displacement = int.Parse(engArgs[2]);
                    efficiency = engArgs[3];
                }

                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(model, engine);
            }

            n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carArgs[0];
                string engModel = carArgs[1];
                int weight = -1;
                string color = "n/a";
                if (carArgs.Length == 3)
                {
                    if(!int.TryParse(carArgs[2], out weight))
                    {
                        weight = -1;
                        color = carArgs[2];
                    }
                }
                
                if (carArgs.Length == 4)
                {
                    weight = int.Parse(carArgs[2]);
                    color = carArgs[3];
                }

                Car car = new Car(model, engines[engModel], weight, color);
                cars.Add(car);
            }

            foreach (Car car1 in cars)
            {
                Console.WriteLine(car1);
            }
        }
    }
}
