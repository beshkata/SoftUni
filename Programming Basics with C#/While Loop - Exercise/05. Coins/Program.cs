using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal changeAmount = decimal.Parse(Console.ReadLine());

            int twoLvCounter = 0;
            int oneLvCounter = 0;
            int fiftyStCounter = 0;
            int twentyStCounter = 0;
            int tenStCounter = 0;
            int fiveStCounter = 0;
            int twoStCounter = 0;
            int oneStCounter = 0;

            while (true)
            {
                if (changeAmount - 2m >= 0)
                {
                    changeAmount -= 2.0m;
                    twoLvCounter++;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (changeAmount - 1m >= 0)
                {
                    changeAmount -= 1.0m;
                    oneLvCounter++;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (changeAmount - 0.5m >= 0)
                {
                    changeAmount -= 0.5m;
                    fiftyStCounter++;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (changeAmount - 0.20m >= 0)
                {
                    changeAmount -= 0.20m;
                    twentyStCounter++;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (changeAmount - 0.1m >= 0)
                {
                    changeAmount -= 0.1m;
                    tenStCounter++;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (changeAmount - 0.05m >= 0)
                {
                    changeAmount -= 0.05m;
                    fiveStCounter++;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (changeAmount - 0.02m >= 0)
                {
                    changeAmount -= 0.02m;
                    twoStCounter++;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                if (changeAmount - 0.01m >= 0)
                {
                    changeAmount -= 0.01m;
                    oneStCounter++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(twoLvCounter + oneLvCounter + fiftyStCounter + twentyStCounter + 
                tenStCounter + fiveStCounter + twoStCounter + oneStCounter);
        }
    }
}
