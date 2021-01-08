using System;

namespace _04._Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
			double distance = double.Parse(Console.ReadLine());
			string firstMeasure = Console.ReadLine();
			string secondMeasure = Console.ReadLine();

			double result = 0.0;

			if (firstMeasure == "m")
			{
				if (secondMeasure == "cm")
				{
					result = distance * 100;
				}
				else if (secondMeasure == "mm")
				{
					result = distance * 1000;
				}
			}
			else if (firstMeasure == "cm")
			{
				if (secondMeasure == "m")
				{
					result = distance / 100;
				}
				else if (secondMeasure == "mm")
				{
					result = distance * 10;
				}
			}
			else if (firstMeasure == "mm")
			{
				if (secondMeasure == "m")
				{
					result = distance / 1000;
				}
				else if (secondMeasure == "cm")
				{
					result = distance / 10;
				}
			}
			else
			{
				result = distance;
			}

			Console.WriteLine("{0:f3}", result);
		}
    }
}
