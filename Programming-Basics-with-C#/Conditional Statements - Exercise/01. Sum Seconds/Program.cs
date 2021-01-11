using System;

namespace _01._Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
			int firstTime = int.Parse(Console.ReadLine());
			int secondTime = int.Parse(Console.ReadLine());
			int thirdTime = int.Parse(Console.ReadLine());

			int fullTimeInSec = firstTime + secondTime + thirdTime;

			int minutes = fullTimeInSec / 60;
			int seconds = fullTimeInSec % 60;

			if (seconds < 10)
			{
				Console.WriteLine("{0}:0{1}", minutes, seconds);
			}
			else
			{
				Console.WriteLine("{0}:{1}", minutes, seconds);
			}
		}
    }
}
