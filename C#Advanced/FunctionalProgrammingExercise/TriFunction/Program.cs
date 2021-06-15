using System;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> isBiggerOrEqual = (a, b) => NameToInt(a,b) >= b;

            foreach (var name in names)
            {
                if (isBiggerOrEqual(name, num))
                {
                    Console.WriteLine(name);
                    return;
                }
            }
        }

        static int NameToInt (string name, int number)
        {
            int nameToInt = 0;

            for (int i = 0; i < name.Length; i++)
            {
                nameToInt += name[i];
            }
            return nameToInt;
        }
    }
}
