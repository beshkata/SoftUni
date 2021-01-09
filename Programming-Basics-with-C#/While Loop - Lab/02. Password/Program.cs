using System;

namespace _02._Password
{
    class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();

            string str = Console.ReadLine();
            while (str != password)
            {
                str = Console.ReadLine();
            }
            if (str == password)
            {
                Console.WriteLine($"Welcome {name}!");
            }
        }
    }
}
