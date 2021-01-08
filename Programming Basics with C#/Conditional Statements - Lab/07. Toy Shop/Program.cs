using System;

namespace _07._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
			const double puzzlePrice = 2.60;
			const double dollPrice = 3.00;
			const double bearPrice = 4.10;
			const double minionPrice = 8.20;
			const double truckPrice = 2.00;

			double excursionPrice = double.Parse(Console.ReadLine());
			int numberOfPuzzles = int.Parse(Console.ReadLine());
			int numberOfDolls = int.Parse(Console.ReadLine());
			int numberOfBears = int.Parse(Console.ReadLine());
			int numberOfMinions = int.Parse(Console.ReadLine());
			int numberOfTrucks = int.Parse(Console.ReadLine());

			bool areToysMoreThanFifty = numberOfPuzzles + numberOfDolls + numberOfBears + numberOfMinions
										 + numberOfTrucks >= 50;
			double fullPrice =
				(numberOfPuzzles * puzzlePrice) +
				(numberOfDolls * dollPrice) +
				(numberOfBears * bearPrice) +
				(numberOfMinions * minionPrice) +
				(numberOfTrucks * truckPrice);

			double discount = fullPrice * 0.25;

			if (areToysMoreThanFifty)
			{
				fullPrice -= discount;
			}

			double shopRent = fullPrice / 10;

			double finalPrice = fullPrice - shopRent;

			if (finalPrice >= excursionPrice)
			{
				Console.WriteLine("Yes! {0:f2} lv left.", finalPrice - excursionPrice);
			}
			else
			{
				Console.WriteLine("Not enough money! {0:f2} lv needed.", excursionPrice - finalPrice);
			}
		}
    }
}
