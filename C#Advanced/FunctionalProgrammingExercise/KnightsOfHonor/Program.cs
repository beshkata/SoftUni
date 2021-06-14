using System;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = n => Console.WriteLine($"Sir {n}");

            string[] names = Console.ReadLine()
                .Split();

            foreach (string name in names)
            {
                printName(name);
            }
        }
    }
}
