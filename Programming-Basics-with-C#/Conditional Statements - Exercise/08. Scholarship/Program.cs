using System;

namespace _08._Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
			double income = double.Parse(Console.ReadLine());
			double averageEvaluation = double.Parse(Console.ReadLine());
			double minSalary = double.Parse(Console.ReadLine());

			bool socialScholarship = false;
			bool excellentScholarship = false;
			bool noScholarship = true;

			double socialScholarshipSize = minSalary * 0.35;
			double excelentScholarshipSize = averageEvaluation * 25;

			bool isSocialBigger = socialScholarshipSize > excelentScholarshipSize;

			if (income < minSalary && averageEvaluation > 4.5)
			{
				socialScholarship = true;
				noScholarship = false;
			}
			if (averageEvaluation >= 5.5)
			{
				excellentScholarship = true;
				noScholarship = false;
			}

			if (noScholarship)
			{
				Console.WriteLine("You cannot get a scholarship!");
			}
			else if (socialScholarship && excellentScholarship)
			{
				if (isSocialBigger)
				{
					Console.WriteLine("You get a Social scholarship {0} BGN", (int)socialScholarshipSize);
				}
				else
				{
					Console.WriteLine("You get a scholarship for excellent results {0} BGN", (int)excelentScholarshipSize);
				}
			}
			else if (socialScholarship)
			{
				Console.WriteLine("You get a Social scholarship {0} BGN", (int)socialScholarshipSize);
			}
			else if (excellentScholarship)
			{
				Console.WriteLine("You get a scholarship for excellent results {0} BGN", (int)excelentScholarshipSize);
			}
		}
    }
}
