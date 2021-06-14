using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> predicate = n => n.Length <= length;

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(n => predicate(n))
                .ToArray();

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
