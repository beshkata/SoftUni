using System;

namespace MathPower
{
    class Program
    {
        static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = GetPower(number, power);

            Console.WriteLine(result);
        }

        private static double GetPower(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}
