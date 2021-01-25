using System;

namespace PokeMon
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int targetsHit = 0;
            int originalN = n;

            while (n >= m)
            {
                targetsHit++;
                n -= m;
                if (n == originalN / 2 && y != 0)
                {
                    n /= y;
                }
            }
            Console.WriteLine(n);
            Console.WriteLine(targetsHit);
        }
    }
}
