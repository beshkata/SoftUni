using System;

namespace BeerKegs
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double bestVolume = 0.0;
            string bestModel = "";

            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > bestVolume)
                {
                    bestVolume = volume;
                    bestModel = model;
                }
            }
            Console.WriteLine(bestModel);
        }
    }
}
