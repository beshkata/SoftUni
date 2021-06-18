using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> strings = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                strings.Add(Console.ReadLine());
            }

            int[] indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Swap(strings, indexes[0], indexes[1]);
            Print(strings);
        }

        public static void Print<T>(List<T> items)
        {
            Type type = typeof(T);
            string name = type.FullName;

            foreach (T item in items)
            {
                Console.WriteLine($"{name}: {item}");
            }
        }

        public static void Swap<T>(List<T>list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
