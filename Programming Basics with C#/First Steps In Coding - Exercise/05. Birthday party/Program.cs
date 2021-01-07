using System;

namespace _05._Birthday_party
{
    class Program
    {
        static void Main(string[] args)
        {
			double hallRent = double.Parse(Console.ReadLine());

			double cakePrise = hallRent * 0.2;
			double drinksPrice = cakePrise - (cakePrise * 0.45);
			double animatorPrice = hallRent / 3;

			double wholeSum = hallRent + cakePrise + drinksPrice + animatorPrice;

			Console.WriteLine(wholeSum);
		}
    }
}
