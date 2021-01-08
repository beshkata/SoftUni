using System;

namespace _06._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
			string str = Console.ReadLine();
			double result = 0.0d;

			if (str == "square")
			{
				double a = double.Parse(Console.ReadLine());
				result = a * a;

			}
			else if (str == "rectangle")
			{
				double a = double.Parse(Console.ReadLine());
				double b = double.Parse(Console.ReadLine());
				result = a * b;
			}
			else if (str == "circle")
			{
				double r = double.Parse(Console.ReadLine());
				result = Math.PI * r * r;
			}
			else if (str == "triangle")
			{
				double a = double.Parse(Console.ReadLine());
				double ha = double.Parse(Console.ReadLine());
				result = a * ha / 2;
			}

			Console.WriteLine("{0:f3}", result);
			Console.ReadLine();
		}
    }
}
