using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "green")
                {
                    int greenLight = greenLightDuration;
                    int freeWindow = freeWindowDuration;

                    while (greenLight > 0 && cars.Count > 0)
                    {
                        string nextCar = cars.Dequeue();
                        greenLight -= nextCar.Length;

                        if (greenLight > 0)
                        {
                            totalCarsPassed++;
                        }
                        else
                        {
                            freeWindow += greenLight;

                            if (freeWindow < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{nextCar} was hit at {nextCar[nextCar.Length + freeWindow]}.");
                                return;
                            }

                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }

    }
}
