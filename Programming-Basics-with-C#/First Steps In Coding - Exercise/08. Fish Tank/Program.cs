using System;

namespace _08._Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
			double length = double.Parse(Console.ReadLine()) / 10;
			double width = double.Parse(Console.ReadLine()) / 10;
			double height = double.Parse(Console.ReadLine()) / 10;
			double percents = double.Parse(Console.ReadLine());
			double tankVolume = length * width * height;


			double waterVolume = tankVolume - (tankVolume * percents / 100);

			Console.WriteLine("{0:f2}", waterVolume);
		}
    }
}
