using System;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main()
        {
            List<int> originalNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbers = new List<int>(originalNumbers.Count);

            for (int i = 0; i < originalNumbers.Count; i++)
            {
                numbers.Add(originalNumbers[i]);
            }
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(commands[1]));
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(commands[1]));
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(commands[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        break;
                    case "Contains":
                        bool hasNumber = numbers.Contains(int.Parse(commands[1]));
                        if (hasNumber)
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        PrintEvenNumbers(numbers);
                        break;
                    case "PrintOdd":
                        PrintOddNumbers(numbers);
                        break;
                    case "GetSum":
                        int elementsSum = GetElementsSum(numbers);
                        Console.WriteLine(elementsSum);
                        break;
                    case "Filter":
                        string condition = commands[1];
                        int num = int.Parse(commands[2]);
                        PrintFilteredNumbers(numbers, condition, num);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
                input = Console.ReadLine();
            }
            bool areEquals = CheckAreListsEquals(originalNumbers, numbers);
            if (!areEquals)
            {
                Console.WriteLine(string.Join(' ', numbers));
            }
        }

        private static bool CheckAreListsEquals(List<int> originalNumbers, List<int> numbers)
        {
            if (originalNumbers.Count != numbers.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < originalNumbers.Count; i++)
                {
                    if (originalNumbers[i] != numbers[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private static void PrintFilteredNumbers(List<int> numbers, string condition, int num)
        {
            List<int> filteredNums = new List<int>();
            int limit = numbers.Count;

            if (condition == "<")
            {
                for (int i = 0; i < limit; i++)
                {
                    if (numbers[i] < num)
                    {
                        filteredNums.Add(numbers[i]);
                    }
                }
            }
            else if (condition == ">")
            {
                for (int i = 0; i < limit; i++)
                {
                    if (numbers[i] > num)
                    {
                        filteredNums.Add(numbers[i]);
                    }
                }
            }
            else if (condition == ">=")
            {
                for (int i = 0; i < limit; i++)
                {
                    if (numbers[i] >= num)
                    {
                        filteredNums.Add(numbers[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < limit; i++)
                {
                    if (numbers[i] <= num)
                    {
                        filteredNums.Add(numbers[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(' ', filteredNums));
        }

        private static int GetElementsSum(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        private static void PrintOddNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintEvenNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
            Console.WriteLine();
        }
    }
}
