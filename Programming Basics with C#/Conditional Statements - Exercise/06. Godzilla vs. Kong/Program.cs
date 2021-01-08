using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
			double movieBuget = double.Parse(Console.ReadLine());
			int actors = int.Parse(Console.ReadLine());
			double dressPricePerActor = double.Parse(Console.ReadLine());

			double decorPrice = movieBuget * 0.1;

			double dressPrice = actors * dressPricePerActor;
			if (actors > 150)
			{
				dressPrice = dressPrice - (dressPrice * 0.1);
			}

			double finalPrice = decorPrice + dressPrice;

			if (finalPrice > movieBuget)
			{
				Console.WriteLine("Not enough money!");
				Console.WriteLine("Wingard needs {0:f2} leva more.", finalPrice - movieBuget);
			}
			else
			{
				Console.WriteLine("Action!");
				Console.WriteLine("Wingard starts filming with {0:f2} leva left.", movieBuget - finalPrice);
			}
		}
    }
}
