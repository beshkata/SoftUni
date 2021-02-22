using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] inputs = input.Split().ToArray();

                string command = inputs[0];

                switch (command)
                {
                    case "Add":
                        numbers.Add(int.Parse(inputs[1]));
                        break;
                    case "Insert":
                        if (isInBounds(numbers.Count, int.Parse(inputs[2])))
                        {
                            numbers.Insert(int.Parse(inputs[2]), int.Parse(inputs[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;
                    case "Remove":
                        if (isInBounds(numbers.Count, int.Parse(inputs[1])))
                        {
                            numbers.RemoveAt(int.Parse(inputs[1]));
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        string direction = inputs[1];
                        int times = int.Parse(inputs[2]);
                        ShiftList(numbers, direction, times);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static bool isInBounds(int count, int index)
        {
            return index >= 0 && index < count;
        }

        private static void ShiftList(List<int> numbers, string direction, int times)
        {
            if (direction == "left")
            {
                for (int i = 0; i < times; i++)
                {
                    int firstNumber = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Add(firstNumber);
                }
            }
            else
            {
                for (int i = 0; i < times; i++)
                {
                    int index = numbers.Count - 1;
                    int lastNumber = numbers[index];
                    numbers.RemoveAt(index);
                    numbers.Insert(0, lastNumber);
                }
            }
        }
    }
}
