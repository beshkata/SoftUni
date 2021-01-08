using System;

namespace _06._Tournament_of_Christmas
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalMoney = 0.0;
            int totalWinCounter = 0;
            int totalLoseCounter = 0;


            for (int i = 0; i < days; i++)
            {
                int winCounter = 0;
                int loseCounter = 0;
                double dayMoney = 0.0;

                string input = Console.ReadLine();

                while (input != "Finish")
                {

                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        winCounter++;
                        totalWinCounter++;
                        dayMoney += 20;
                    }
                    else
                    {
                        loseCounter++;
                        totalLoseCounter++;
                    }
                    input = Console.ReadLine();
                }
                if (winCounter > loseCounter)
                {
                    dayMoney += dayMoney * 0.1;
                }
                totalMoney += dayMoney;
            }
            if (totalWinCounter > totalLoseCounter)
            {
                totalMoney += totalMoney * 0.2;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoney:f2}");
            }
        }
    }
}
