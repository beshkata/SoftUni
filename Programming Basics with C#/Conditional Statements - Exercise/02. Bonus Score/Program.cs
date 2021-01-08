using System;

namespace _02._Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
			int points = int.Parse(Console.ReadLine());
			double bonusPoints = 0.0;
			double finalPoints = 0.0;

			if (points <= 100)
			{
				bonusPoints = 5;
			}
			else if (points > 100 && points <= 1000)
			{
				bonusPoints = points * 0.2;
			}
			else
			{
				bonusPoints = points * 0.1;
			}

			if (points % 2 == 0)
			{
				bonusPoints += 1;
			}

			if (points % 5 == 0 && points % 10 != 0)
			{
				bonusPoints += 2;
			}
			finalPoints = points + bonusPoints;
			Console.WriteLine(bonusPoints);
			Console.WriteLine(finalPoints);
		}
    }
}
