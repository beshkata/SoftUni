using System;

namespace _06._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= firstNum; i++)
            {
                string pin = "";

                for (int j = 1; j <= secondNum; j++)
                {
                    for (int k = 1; k <= thirdNum; k++)
                    {
                        if (k % 2 == 0 && i % 2 == 0 && (j == 2 || j == 3 || j == 5 || j == 7))
                        {
                            pin = i.ToString() + " " + j.ToString() + " " + k.ToString();
                            Console.WriteLine(pin);

                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
