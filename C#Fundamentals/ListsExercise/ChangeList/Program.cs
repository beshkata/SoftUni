using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangeList
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputs = input.Split();
                string command = inputs[0];

                if (command == "Delete")
                {
                    int element = int.Parse(inputs[1]);
                    numbers.RemoveAll(x => x == element);
                }
                else
                {
                    int index = int.Parse(inputs[2]);
                    int element = int.Parse(inputs[1]);

                    numbers.Insert(index, element);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
