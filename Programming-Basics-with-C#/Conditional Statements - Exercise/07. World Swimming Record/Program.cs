using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
			double record = double.Parse(Console.ReadLine());
			double distance = double.Parse(Console.ReadLine());
			double secondsPerMeter = double.Parse(Console.ReadLine());

			int delay = (int)distance / 15;

			double finalTime = distance * secondsPerMeter + (delay * 12.5);

			if (finalTime < record)
			{
				Console.WriteLine("Yes, he succeeded! The new world record is {0:f2} seconds.", finalTime);
			}
			else
			{
				Console.WriteLine("No, he failed! He was {0:f2} seconds slower.", finalTime - record);
			}
		}
    }
}
