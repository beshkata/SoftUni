using System;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = n => Console.WriteLine(n);

            string[] names = Console.ReadLine()
                .Split();

            foreach (string name in names)
            {
                printName(name);
            }
        }
    }
}
