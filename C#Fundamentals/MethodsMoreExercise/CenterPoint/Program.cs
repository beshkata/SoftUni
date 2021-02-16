using System;

namespace CenterPoint
{
    class Program
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintPointClosestToCentre(x1, y1, x2, y2);
        }

        private static void PrintPointClosestToCentre(double x1, double y1, double x2, double y2)
        {
            double distanceToCentreFirst = GetAbsDistanceToCentre(x1, y1);
            double distanceToCentreSecond = GetAbsDistanceToCentre(x2, y2);

            if (distanceToCentreFirst <= distanceToCentreSecond)
            {
                PrintPoint(x1, y1);
            }
            else
            {
                PrintPoint(x2, y2);
            }
        }

        private static double GetAbsDistanceToCentre(double x1, double y1)
        {
            double distance = Math.Abs(x1) + Math.Abs(y1);
            return distance;
        }

        private static void PrintPoint(double x1, double y1)
        {
            Console.WriteLine($"({x1}, {y1})");
        }
    }
}
