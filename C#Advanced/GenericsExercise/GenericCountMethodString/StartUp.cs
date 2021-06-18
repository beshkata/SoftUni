using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>(n);

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                boxes.Add(box);
            }

            string stringToCompare = Console.ReadLine();

            int result = GetNumberOfLarger(boxes, stringToCompare);
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
