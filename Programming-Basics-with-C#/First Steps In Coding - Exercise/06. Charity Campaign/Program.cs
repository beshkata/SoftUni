using System;

namespace _06._Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
			const double cakePrice = 45;
			const double wafflePrice = 5.80;
			const double panecakePrice = 3.20;

			int numberOfDays = int.Parse(Console.ReadLine());
			int numberOfConfectioners = int.Parse(Console.ReadLine());
			int numberOfCakes = int.Parse(Console.ReadLine());
			int numberOfWaffles = int.Parse(Console.ReadLine());
			int numberOfPanecakes = int.Parse(Console.ReadLine());

			double sumPerConfectioner = numberOfDays * (numberOfCakes * cakePrice + numberOfWaffles * wafflePrice + numberOfPanecakes * panecakePrice);

			double wholeSum = sumPerConfectioner * numberOfConfectioners;

			double finalSum = wholeSum - (wholeSum / 8);

			Console.WriteLine(finalSum);
		}
    }
}
