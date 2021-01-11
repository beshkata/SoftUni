using System;

namespace _07._Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
			double strawberriesPrice = double.Parse(Console.ReadLine());
			double bananaQuantity = double.Parse(Console.ReadLine());
			double orangeQuantity = double.Parse(Console.ReadLine());
			double raspberyQuantity = double.Parse(Console.ReadLine());
			double strawberryQuantity = double.Parse(Console.ReadLine());

			double raspberriesPrice = strawberriesPrice / 2;
			double orangesPrice = raspberriesPrice - (raspberriesPrice * 0.4);
			double bananasPrice = raspberriesPrice - (raspberriesPrice * 0.8);

			double finalSum = bananaQuantity * bananasPrice + orangeQuantity * orangesPrice +
								raspberyQuantity * raspberriesPrice + strawberryQuantity * strawberriesPrice;
			Console.WriteLine("{0:f2}", finalSum);
		}
    }
}
