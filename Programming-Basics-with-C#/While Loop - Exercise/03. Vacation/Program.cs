using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double balance = double.Parse(Console.ReadLine());

            string action = Console.ReadLine();
            double amountMoney = double.Parse(Console.ReadLine());
            int daysSpend = 0;
            int dayCounter = 0;

            while (true)
            {
                dayCounter++;
                if (action == "spend")
                {
                    daysSpend++;
                    balance -= amountMoney;
                    if (balance < 0)
                    {
                        balance = 0;
                    }
                }
                else
                {
                    balance += amountMoney;
                    daysSpend = 0;
                    if (balance >= neededMoney)
                    {
                        break;
                    }
                }

                if (daysSpend == 5)
                {
                    break;
                }
                action = Console.ReadLine();
                amountMoney = double.Parse(Console.ReadLine());
            }

            //output
            if (balance >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {dayCounter} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(dayCounter);
            }
        }
    }
}
