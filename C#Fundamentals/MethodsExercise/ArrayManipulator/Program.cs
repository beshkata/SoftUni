using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commands = command.Split(' ');
                switch (commands[0])
                {
                    case "exchange":
                        numbers = Exchange(numbers, int.Parse(commands[1]));
                        break;
                    case "max":
                        if (commands[1] == "odd")
                        {
                            PrintMaxOddIndex(numbers);
                        }
                        else
                        {
                            PrintMaxEvenIndex(numbers);
                        }
                        break;
                    case "min":
                        if (commands[1] == "odd")
                        {
                            PrintMinOddIndex(numbers);
                        }
                        else
                        {
                            PrintMinEvenIndex(numbers);
                        }
                        break;
                    case "first":
                        PrintFirstNNumbers(numbers, int.Parse(commands[1]), commands[2]);
                        break;
                    case "last":
                        PrintLastNNumbers(numbers, int.Parse(commands[1]), commands[2]);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void PrintLastNNumbers(int[] numbers, int count, string typeOfNumbers)
        {
            List<int> lastFoundNums = new List<int>(count);
            int index = -1;
            if (count < 0 || count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (typeOfNumbers == "even")
                {
                    if (numbers[i] % 2 == 0)
                    {
                        index++;
                        lastFoundNums.Insert(0, numbers[i]);
                    }
                }
                else
                {
                    if (numbers[i] % 2 == 1)
                    {
                        index++;
                        lastFoundNums.Insert(0, numbers[i]);
                    }
                }

                if (index == count - 1)
                {
                    break;
                }

            }
            if (index < 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine($"[{string.Join(", ", lastFoundNums)}]");
            }

        }

        private static void PrintFirstNNumbers(int[] numbers, int count, string typeOfNumbers)
        {
            List<int> firstFoundNums = new List<int>(count);
            int index = -1;
            if (count < 0 || count > numbers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            foreach (int number in numbers)
            {
                if (typeOfNumbers == "even")
                {
                    if (number % 2 == 0)
                    {
                        index++;
                        firstFoundNums.Add(number);
                    }
                }
                else
                {
                    if (number % 2 == 1)
                    {
                        index++;
                        firstFoundNums.Add(number);
                    }
                }

                if (index == count - 1)
                {
                    break;
                }
            }
            if (index < 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine($"[{string.Join(", ", firstFoundNums)}]");
            }
        }

        private static void PrintMinEvenIndex(int[] numbers)
        {
            int index = -1;
            int minEven = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] <= minEven)
                    {
                        index = i;
                        minEven = numbers[i];
                    }
                }
            }
            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void PrintMinOddIndex(int[] numbers)
        {
            int index = -1;
            int minOdd = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    if (numbers[i] <= minOdd)
                    {
                        index = i;
                        minOdd = numbers[i];
                    }
                }
            }
            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }

        private static void PrintMaxEvenIndex(int[] numbers)
        {
            int index = -1;
            int maxEven = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    if (numbers[i] >= maxEven)
                    {
                        index = i;
                        maxEven = numbers[i];
                    }
                }
            }
            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void PrintMaxOddIndex(int[] numbers)
        {
            int index = -1;
            int maxOdd = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    if (numbers[i] >= maxOdd)
                    {
                        index = i;
                        maxOdd = numbers[i];
                    }
                }
            }
            if (index >= 0)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static int[] Exchange(int[] numbers, int index)
        {
            if (index < 0 || index >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }
            
            for (int i = 0; i <= index; i++)
            {
                int firstNum = numbers[0];
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                numbers[numbers.Length - 1] = firstNum;
            }
            return numbers;
        }
    }
}
