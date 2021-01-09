using System;

namespace _03._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
			double deposit = double.Parse(Console.ReadLine());
			int termInMonths = int.Parse(Console.ReadLine());
			double annualInterest = double.Parse(Console.ReadLine());

			double InterestPerYear = deposit * annualInterest / 100;
			double InterestPerMonth = InterestPerYear / 12;

			double finalSum = deposit + InterestPerMonth * termInMonths;

			Console.WriteLine(finalSum);
		}
    }
}
