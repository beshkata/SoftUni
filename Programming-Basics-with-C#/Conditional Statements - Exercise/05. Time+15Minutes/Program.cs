using System;

namespace _05._Time_15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
			int hour = int.Parse(Console.ReadLine());
			int minutes = int.Parse(Console.ReadLine());

			if (minutes + 15 >= 60)
			{
				minutes = (minutes + 15) - 60;
				if (hour < 23)
				{
					hour++;
				}
				else
				{
					hour = 0;
				}
			}
			else
			{
				minutes += 15;
			}

			if (minutes < 10)
			{
				Console.WriteLine("{0}:0{1}", hour, minutes);
			}
			else
			{
				Console.WriteLine("{0}:{1}", hour, minutes);
			}
		}
    }
}
