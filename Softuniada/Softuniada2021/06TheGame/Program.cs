using System;
using System.Collections.Generic;
using System.Linq;

namespace _06TheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string current = Console.ReadLine();
            string final = Console.ReadLine();
            int counter = 0;
            List<char> list = current.ToCharArray().ToList();
            bool isPosible = false;

            for (int i = 0; i < final.Length; i++)
            {
                char last = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                list.Insert(0, last);
                counter++;
                if (final == string.Join("", list))
                {
                    isPosible = true;
                    break;
                }
            }

            if (isPosible)
            {
                Console.WriteLine($"The minimum operations required to convert \"{current}\" to \"{final}\" are {counter}");
            }
            else
            {
                Console.WriteLine("The name cannot be transformed!");
            }
        }
    }
}
