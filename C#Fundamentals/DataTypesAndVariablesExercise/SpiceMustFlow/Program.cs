using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main()
        {
            int yield = int.Parse(Console.ReadLine());
            long totalSpice = 0;
            int days = 0;
            if (yield >= 100)
            {
                while (yield >= 100)
                {
                    days++;
                    totalSpice += yield - 26;
                    yield -= 10;
                }
                totalSpice -= 26;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
