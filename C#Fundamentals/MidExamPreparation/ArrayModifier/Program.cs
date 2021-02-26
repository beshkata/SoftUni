using System;
using System.Linq;

namespace ArrayModifier
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string line = Console.ReadLine();
            int index1 = 0;
            int index2 = 0;

            while (line != "end")
            {
                string[] commands = line.Split();
                string command = commands[0];

                switch (command)
                {
                    case "swap":
                        index1 = int.Parse(commands[1]);
                        index2 = int.Parse(commands[2]);
                        SwapElements(numbers, index1, index2);
                        break;
                    case "multiply":
                        index1 = int.Parse(commands[1]);
                        index2 = int.Parse(commands[2]);
                        MultiplyElement(numbers, index1, index2);
                        break;
                    case "decrease":
                        DecreaseElementsByOne(numbers);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void DecreaseElementsByOne(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }
        }

        private static void MultiplyElement(int[] numbers, int index1, int index2)
        {
            numbers[index1] *= numbers[index2];
        }

        private static void SwapElements(int[] numbers, int index1, int index2)
        {
            int firstElement = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = firstElement;
        }
    }
}
