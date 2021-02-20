using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main()
        {
            List<int> train = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while(input != "end")
            {
                string[] inputs = input.Split().ToArray();
                
                if (inputs.Length == 2)
                {
                    int wagon = int.Parse(inputs[1]);
                    train.Add(wagon);
                }
                else
                {
                    int passengers = int.Parse(inputs[0]);

                    for (int i = 0; i < train.Count; i++)
                    {
                        if (train[i] + passengers <= capacity)
                        {
                            train[i] += passengers;
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', train));
        }
    }
}
