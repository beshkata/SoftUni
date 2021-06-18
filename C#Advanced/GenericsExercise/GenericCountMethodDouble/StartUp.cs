using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new List<Box<double>>(n);

            for (int i = 0; i < n; i++)
            {
                Box<double> box = new Box<double>(double.Parse(Console.ReadLine()));
                boxes.Add(box);
            }

            double doubleToCompare = double.Parse(Console.ReadLine());

            int result = GetNumberOfLarger(boxes, doubleToCompare);
            Console.WriteLine(result);
        }

        private static int GetNumberOfLarger<T>(List<Box<T>> elements, T elementToCompare)
            where T : IComparable
        {
            int counter = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Value.CompareTo(elementToCompare) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
