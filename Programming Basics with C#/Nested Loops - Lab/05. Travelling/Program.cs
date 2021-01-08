using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main()
        {
            string destination = Console.ReadLine();

            while (true)
            {
                if (destination == "End")
                {
                    break;
                }
                decimal neededMoney = decimal.Parse(Console.ReadLine());

                decimal savedMoney = 0.0m;
                decimal currentSum = 0.0m;

                while (true)
                {
                    string currentInput = Console.ReadLine();
                    if (decimal.TryParse(currentInput, out savedMoney))
                    {
                        currentSum += savedMoney;
                        if (currentSum >= neededMoney)
                        {
                            Console.WriteLine($"Going to {destination}!");
                            break;
                        }
                    }
                    else
                    {
                        if (currentInput != "End")
                        {
                            destination = currentInput;
                            neededMoney = decimal.Parse(Console.ReadLine());
                        }
                        else
                        {
                            destination = currentInput;
                            break;
                        }
                    }
                }
                destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
            }
        }
    }
}
