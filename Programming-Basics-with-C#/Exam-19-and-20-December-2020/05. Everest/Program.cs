using System;

namespace _05._Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            int meters = 5364;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "Yes")
                {
                    count++;
                }
                int metersClimb = int.Parse(Console.ReadLine());
                if (count > 5)
                {
                    break;
                }
                meters += metersClimb;
                if (meters >= 8848)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (meters < 8848)
            {
                Console.WriteLine("Failed!");
                Console.WriteLine(meters);
            }
            else
            {
                Console.WriteLine($"Goal reached for {count} days!");
            }
        }
    }
}
